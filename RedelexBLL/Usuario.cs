using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedelexDataModel;

namespace RedelexBLL
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Cuenta Cuenta { get; set; }
        public System.Guid Token { get; set; }

        public bool Login(string UsuarioNombre, string Password)
        {
            RedelexDataModel.Usuario u = new RedelexDataModel.Usuario();

            if (u.Login(UsuarioNombre, Password))
            {
                this.Id = u.Id;
                this.Nombre = u.Nombre;
                this.Cuenta = new Cuenta();
                this.Cuenta.Id = u.CuentaActiva.Id;
                this.Cuenta.Nombre = u.CuentaActiva.Nombre;
                this.Token = u.Token;

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
