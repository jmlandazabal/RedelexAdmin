using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedelexDataModel
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Cuenta CuentaActiva { get; set; }
        public int DiferenciaHoraria { get; set; }
        public System.Guid Token { get; set; }

        private RedelexEntities context = new RedelexEntities();

        public bool Login(string UsuarioNombre, string Password)
        {
            var _query = (from u in context.v_usuarios_cuentas
                          where u.codigo.Equals(UsuarioNombre)
                          select new { UsuarioID = u.id_usuario, UsuarioNombre = u.nombre, CuentaNombre = u.nombre_cliente, CuentaId = u.id_cuenta, DiferenciaHoraria = 0 }).FirstOrDefault();

            if (_query != null)

            {
                this.Id = _query.UsuarioID;
                this.Nombre = _query.UsuarioNombre;
                this.CuentaActiva = new Cuenta();
                this.CuentaActiva.Id = _query.CuentaId;
                this.CuentaActiva.Nombre = _query.CuentaNombre;
                this.DiferenciaHoraria = _query.DiferenciaHoraria;

                var _token = (from t in context.tokens
                              where t.id_usuario == this.Id && t.id_cuenta.Equals(this.CuentaActiva.Nombre)
                              select t.token).FirstOrDefault();

                if (_token != null)
                    this.Token = _token;

                return true;
            }

            

            
            return false;
        }
    }

    public class Cuenta
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
    }
}
