using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedelexBLL;

namespace RedelexAdmin.Controllers
{
    public class ClientesController : Controller
    {
        
        
        //
        // GET: /Clientes/
        [VerifyUserAttribute]
        public ActionResult Index()
        {
            return View();
        }

        ////
        //// GET: /Clientes/TablaClientes/5
        public ActionResult TablaClientes(int? id) // Partial View
        {
            

            if (id == null)
            {
                ViewBag.TipoLicencia = "Todas las Cuentas Activas";
                ViewBag.TipoLicenciaId = "-";
                
                return View(RedelexBLL.Clientes.Select.GetClientesPorLicencia(null).OrderByDescending(a => a.LicenciaInfo.FechaExpiracion));
                //return View(db.clientes.Where(a => a.activo.Equals(true)).OrderByDescending(a => a.fecha_expiracion).ToList());

            }
            string _tipoLicencia = RedelexBLL.Licencias.Select.TipoLicencia(id);
            
            ViewBag.TipoLicencia = _tipoLicencia;
            ViewBag.TipoLicenciaId = id;
            
            List<RedelexDTO.ClienteDetalleInfo> model = new List<RedelexDTO.ClienteDetalleInfo>();
            model = RedelexBLL.Clientes.Select.GetClientesPorLicencia(id).OrderBy(a => a.LicenciaInfo.FechaExpiracion).ToList();

            return View(model);
        }

        //[VerifyUserAttribute]
        //public ActionResult ClientesPorLicencia(int id)
        //{
        //    return View(db.clientes.Where(a => a.activo.Equals(true) && a.TipoLicenciaId == id).OrderByDescending(a => a.fecha_expiracion).ToList());
        //}


        ////
        //// GET: /Clientes/MovimientosVJConnect/5
        public ActionResult MovimientosVJConnect(string id) // Partial View
        {
            RedelexDTO.Estadisticas _e = new RedelexDTO.Estadisticas(30);
            _e = RedelexBLL.Clientes.Select.GetMovimientosVJConnect(id, 30);
            return View(_e);

        }

        ////
        //// GET: /Clientes/TablaClientes/5
        public ActionResult HTTP500Errors(string id) // Partial View
        {
            List<RedelexDTO.HTTP500Errors> _errors = new List<RedelexDTO.HTTP500Errors>();
            _errors = RedelexBLL.Clientes.Select.GetAuditoria(id);
            return View(_errors);

        }

        ////
        //// GET: /Clientes/Details/5

        //[VerifyUserAttribute]
        //public ActionResult Details(string id = null)
        //{
        //    clientes clientes = db.clientes.Find(id);
        //    if (clientes == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clientes);
        //}
        //// GET: /Clientes/InfoCliente/5

        //[VerifyUserAttribute]
        public ActionResult InfoCliente(string id = null)
        {
            RedelexBLL.Clientes.ClientesDetalleInfo cliente = new Clientes.ClientesDetalleInfo(id);

            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuentaId = id;
            return View(cliente);
        }
        //
        // GET: /Clientes/Create

        [VerifyUserAttribute]
        public ActionResult Create()
        {
            return View();
        }

        ////
        //// POST: /Clientes/Create

        //[VerifyUserAttribute]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(clientes clientes)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.clientes.Add(clientes);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(clientes);
        //}

        //
        // GET: /Clientes/Edit/5

        [VerifyUserAttribute]
        public ActionResult Edit(string id = null)
        {
            RedelexDTO.ClienteDetalleInfo clientes = RedelexBLL.Clientes.Select.GetInfoCuenta(id);
            
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        //
        // POST: /Clientes/Edit/5

        [VerifyUserAttribute]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RedelexDTO.ClienteDetalleInfo clientes)
        {
            if (ModelState.IsValid)
            {
                RedelexBLL.Clientes.Update.InfoBasica(clientes);
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        ////
        //// GET: /Clientes/Delete/5

        //[VerifyUserAttribute]
        //public ActionResult Delete(string id = null)
        //{
        //    clientes clientes = db.clientes.Find(id);
        //    if (clientes == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(clientes);
        //}

        ////
        //// POST: /Clientes/Delete/5

        //[VerifyUserAttribute]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    clientes clientes = db.clientes.Find(id);
        //    db.clientes.Remove(clientes);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        public ActionResult Licencias()
        {
            return Json(new[] {
            new { Id = 1, Value = "Demostracion" },
            new { Id = 2, Value = "Contrato - Pago Anual" },
            new { Id = 4, Value = "Contrato - Pago Mensual" },
            new { Id = 3, Value = "Contrato - Gratis" }
            }, JsonRequestBehavior.AllowGet);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}

        //private ClientesDetalleInfo GetClienteAuditoria(string CuentaId)
        //{
        //    ClientesDetalleInfo _detalle = new ClientesDetalleInfo(CuentaId);

        //    return _detalle;
        //}

    }
}