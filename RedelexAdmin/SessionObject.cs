using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RedelexAdmin
{
    public class SessionObject
    {
        public Usuario Usuario { get; set; }
        public Cuenta Cuenta { get; set; }
    }

    public class Usuario
    {
        public string Id
        {
            get
            {
                return HttpContext.Current.Session["UsuarioId"].ToString();
            }
            set
            {
                HttpContext.Current.Session["UsuarioId"] = value;
            }
        }
        public string Nombre
        {
            get
            {
                return HttpContext.Current.Session["UsuarioNombre"].ToString();
            }
            set
            {
                HttpContext.Current.Session["UsuarioNombre"] = value;
            }
        }
        public int DiferenciaHoraria { get; set; }
        public string Token { get; set; }

        public static implicit operator Usuario(RedelexBLL.Usuario typ)
        {


            // code to convert from  MyType to MyOtherType 
            // and return a MyOtherType object ie.
            // public static implicit operator MyOtherType(MyType typ)
            //MyOtherType m = new MyOtherType();
            //m.MyOtherTypeProperty = typ.MyTypeProperty;
            //return m;

            Usuario m = new Usuario();
            m.Id = typ.Id.ToString();
            m.Nombre = typ.Nombre;
            m.Token = typ.Token.ToString();
            m.DiferenciaHoraria = 0;

            return m;
        }
    }
    public class Cuenta
    {
        public string Id
        {
            get
            {
                return HttpContext.Current.Session["CuentaId"].ToString();
            }
            set
            {
                HttpContext.Current.Session["CuentaId"] = value;
            }
        }
        public string Nombre
        {
            get
            {
                return HttpContext.Current.Session["CuentaNombre"].ToString();
            }
            set
            {
                HttpContext.Current.Session["CuentaNombre"] = value;
            }

        }

        public static implicit operator Cuenta(RedelexBLL.Cuenta typ)
        {


            // code to convert from  MyType to MyOtherType 
            // and return a MyOtherType object ie.
            // public static implicit operator MyOtherType(MyType typ)
            //MyOtherType m = new MyOtherType();
            //m.MyOtherTypeProperty = typ.MyTypeProperty;
            //return m;

            Cuenta m = new Cuenta();
            m.Id = typ.Id.ToString();
            m.Nombre = typ.Nombre;


            return m;
        }
    }


}