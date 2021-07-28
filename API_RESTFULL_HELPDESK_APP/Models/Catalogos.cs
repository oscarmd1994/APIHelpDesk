using System;
using System.ComponentModel.DataAnnotations;

namespace API_RESTFULL_HELPDESK_APP.Controllers.Models
{
    public class Catalogos
    {
    }

    public class CTipoServicio
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoServicio { get; set; }
        public string Nombre { get; set; }
        public int Cancelado { get; set; }
    }
    public class Respuestas
    {
        public string iFlag { get; set; }
        public string sMessage { get; set; }
    }
    public class CModalidades {
        [Key]
        public int Id { get; set; }
        public string NombreModalidad { get; set; }
        public int TipoServicio_id { get; set; }
        public int Prioridad_id { get; set; }
        public string TiempoRespuesta { get; set; }
        public int Cancelado { get; set; }
    }
    public class TTickets
    {
        [Key]
        public Int64 IdTicket { get; set; }
        public string Nombre_solicitante { get; set; }
        public int Empresa_id { get; set; }
        public string Descripcion_problema { get; set; }
        public int Usuario_asignado_id { get; set; }
        public int Modalidad_id { get; set; }
        public int Status_id { get; set; }
        public DateTime Fecha_creacion { get; set; }
    }
    public class vw_TTickets {
        [Key]
        public Int64 IdTicket { get; set; }
        public int Empresa_id { get; set; }
        public string Descripcion_problema { get; set; }
        public int Modalidad_id { get; set; }
        public string NombreModalidad { get; set; }
        public int Status_id { get; set; }
        public string Status { get; set; }
        public int Usuario_asignado_id { get; set; }
        public string Usuario_asignado { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public int Prioridad_id { get; set; }
    }
    public class MotivosEscalamiento
    {
        public int Id { get; set; }
        public int Ticket_id { get; set; }
        public int Usuario_asignado_id { get; set; }
	    public int Usuario_solicitante_id { get; set; }
	    public DateTime Fecha_escalamiento { get; set; }
	    public string Motivo_escalamiento { get; set; }
	    public string Descripcion { get; set; }
    }
    public class Prioridades
    {
        [Key]
        public int IdPrioridad { get; set; }
        public string Tipo { get; set; }
        public int Cancelado { get; set; }
    }
    public class CEmpresas
    {
        [Key]
        public int Id { get; set; }
        public string NombreEmpresa { get; set; }
        public int Cancelado { get; set; }
    }
    public class TUsuarios { 
        [Key]
        public int IdUsuario { get; set; }
        public int TipoUser_id { get; set; }
        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Passw { get; set; }
        public int Cancelado { get; set; }
    }
    public class NewToken {
        public string User { get; set; }
        public string token { get; set; }
    }

    public class DetalleTickets {
        public string idTicket { get; set; }
        public string empresaId { get; set; }
        public string nombreEmpresa { get; set; }
        public string descripcionProblema { get; set; }
        public string modalidadId { get; set; }
        public string nombreModalidad { get; set; }
        public string statusId { get; set; }
        public string status { get; set; }
        public string prioridadId { get; set; }
        public string prioridad { get; set; }
        public string usuarioSolicitante { get; set; }
        public string usuarioSolicitanteId { get; set; }
        public string usuarioAsignado { get; set; }
        public string usuarioAsignadoId { get; set; }
        public string fechaCreacion { get; set; }
        public string fechaAsignacion { get; set; }
        public string fechaProcesamiento { get; set; }
        public string fechaTermino { get; set; }
    }
}
