using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedelexDTO
{
    
    public partial class ProcesoEncabezado
    {
        public string CuentaId { get; set; }
        public int ProcesoId { get; set; }
        public string Demandante { get; set; }
        public string Demandado { get; set; }
        public string Referencia { get; set; }
        public Estados Estado { get; set; }
        public bool Eliminado { get; set; }
        public int UsuarioCreacion { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public DateTime FechaHoraEliminacion { get; set; }
        public Despachos DespachoConocimiento { get; set; }

        public int UsuarioEliminacion { get; set; }
    }

    public class ClaseProcesos
    {
        public int ClaseProcesoId { get; set; }
        public string Nombre { get; set; }
        public Jurisdicciones Jurisdiccion { get; set; }
        public bool Eliminado { get; set; }
        public Usuarios UsuarioEliminacion { get; set; }
        public Usuarios UsuarioInsercion { get; set; }
    }
    public class Procesos : ProcesoEncabezado
    {

        public List<Actuaciones> Actuaciones { get; set; }
        public List<Sujetos> Sujetos { get; set; }
        public List<Despachos> Despachos { get; set; }
        public List<Abogados> Abogados { get; set; }

        public Procesos()
        {
        }

    }
    public class TipoActuaciones
    {
        public int TipoActuacionId { get; set; }
        public TipoEtapas Etapa { get; set; }
        public string Nombre { get; set; }
    }

    public class TipoEtapas
    {
        public int TipoEtapaId { get; set; }
        public string Nombre { get; set; }
        public bool Eliminado { get; set; }
    }
    public class Actuaciones
    {
        public int ActuacionId { get; set; }
        public TipoActuaciones TipoActuacion { get; set; }
        public TipoProvidencias Providencia { get; set; }
        public string Observacion { get; set; }
        public Usuarios UsuarioInsercion { get; set; }
        public Cuentas Cuenta { get; set; }
        public Usuarios UsuarioEliminacion { get; set; }
        public DateTime FechaHoraInsercion { get; set; }
        public DateTime? FechaHoraEliminacion { get; set; }
        public bool Eliminado { get; set; }
    }

    public class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }

    }
    public class Cuentas
    {
        public int CuentaId { get; set; }
        public string Nombre { get; set; }
    }
    public class Despachos
    {
        public TipoDespachos TipoDespacho { get; set; }
        public string Nombre { get; set; }
        public int Numero { get; set; }
        public Recursos Recurso { get; set; }
        public Instancias Instancia { get; set; }
        public TipoProvidencias Providencia { get; set; }
    }

    public class TipoProvidencias
    {
        public int TipoProvidencia { get; set; }
        public int Nombre { get; set; }
        public List<Recursos> Recursos { get; set; }
    }

    public class Tramites
    {
        public int TramiteId { get; set; }
        public string Nombre { get; set; }
    }

    public class Instancias
    {
        public int TipoInstancia { get; set; }
        public string Nombre { get; set; }
    }

    public class Recursos
    {
        public int TipoRecurso { get; set; }
        public string Nombre { get; set; }
    }

    public class TipoDespachos
    {
        public int TipoDespacho { get; set; }
        public string Nombre { get; set; }
    }
    public class Sujetos
    {
        public int ProcesoId { get; set; }
        public int SujetoId { get; set; }
        public string Nombre { get; set; }
        public string TipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public int TipoSujeto { get; set; }
        public int Tipo { get; set; }
    }

    public class Jurisdicciones
    {
        public int JurisdiccionId { get; set; }
        public string Nombre { get; set; }
    }

    public class Estados
    {
        public int TipoEstado { get; set; }
        public string Nombre { get; set; }
    }
    public class Pretensiones
    {
        public TipoPretensiones TipoPretension { get; set; }
        public int Valor { get; set; }
        public TipoMonedas TipoMoneda { get; set; }
        public int MyProperty { get; set; }
    }

    public class TipoMonedas
    {
        public int TipoMoneda { get; set; }
        public string Nombre { get; set; }
        public string CodigoMoneda { get; set; }
    }

    public class TipoPretensiones
    {
        public int TipoPretension { get; set; }
        public string Nombre { get; set; }
    }
    public class Abogados
    {
        public int AbogadoId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public TipoAbogados TipoAbogado { get; set; }
    }

    public class TipoAbogados
    {
        public int TipoAbogadoId { get; set; }
        public string Nombre { get; set; }
    }
}
