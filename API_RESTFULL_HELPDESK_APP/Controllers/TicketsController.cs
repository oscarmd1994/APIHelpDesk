using API_RESTFULL_HELPDESK_APP.Controllers.Conexion;
using API_RESTFULL_HELPDESK_APP.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using API_RESTFULL_HELPDESK_APP.Models;

namespace API_RESTFULL_HELPDESK_APP.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
        private readonly ConexionApp context;

        public TicketsController(ConexionApp context)
        {
            this.context = context;
        }
        //////////////////
        /// GET
        //////////////////
        [HttpGet]
        public ActionResult GetTicketsList()
        {
            //return context.vw_TTickets.ToList();
            try
            {
                TTicketsDao Dao = new TTicketsDao();
                List<vw_TTickets> tickets = new List<vw_TTickets>();
                tickets = Dao.sp_Tickets_getTickets();

                //envio de correos de notificacion a encargados
                MailConfig mailSender = new MailConfig();
                string message = "" +
                    "<table>" +
                        "<tr>" +
                            "<td><img src='cid:addfile'></td>" +
                            "<td><h3 style='align-items: center; text-align: inherit;'> Se agregó un nuevo ticket de soporte.</td>" +
                        "</tr>" +
                    "</table>" +
                    "<hr><br>" +
                    "<table>" +
                        "<tr>" +
                            "<td><img src='cid:bell'></td>" +
                            "<td><h4 style='color: maroon;'>&nbsp;Prioridad:&nbsp;</h4></td>" +
                            "<td>2</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><img src='cid:user'></td>" +
                            "<td><h4 style='color: maroon;'>&nbsp;Usuario:&nbsp;</h4></td>" +
                            "<td>oscarm</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><img src='cid:category'></td>" +
                            "<td><h4 style='color: maroon;'>&nbsp;Tipo Soporte:&nbsp;</h4></td>" +
                            "<td>Papeleria</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><img src='cid:bubble'></td>" +
                            "<td><h4 style='color: maroon;'>&nbsp;Descripción:&nbsp;</h4></td>" +
                            "<td>Se solicitan 2 paquetes de hojas de 500</td>" +
                        "</tr>" +
                    "</table>" +
                    "<br><br>" +
                    "<div><img width='50%' src='cid:logo_app'></div>" +
                    "<p><small>Aplicación de soporte tecnico RACI TI</small></p>" +
                    "<hr>" +
                    "<p><small>Este es un correo electrónico automático únicamente informativo, no responder notificaciones dentro del mismo.</small></p>";

                bool mailOk = false;
                mailOk = mailSender.CustomMail("fernandoc@raciti.com.mx", "Nuevo ticket HELP DESK", message);

                if (mailOk)
                {
                    Console.WriteLine("Enviado");
                }

                return Ok(tickets.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public TTickets Get(int id)
        {
            TTickets tickets = context.TTickets.FirstOrDefault(p => p.IdTicket == id);
            return tickets;
        }
        //////////////////
        /// POST
        //////////////////
        [HttpPost]
        public ActionResult Post([FromBody] int IdTicket, int Empresa_id, string Nombre_solicitante, string Descripcion_problema, int Usuario_asignado_id, int Modalidad_id, int Status_id, DateTime Fecha_creacion)
        {
            try
            {
                TTickets tickets = new TTickets();
                tickets.IdTicket = IdTicket;
                tickets.Nombre_solicitante = Nombre_solicitante;
                tickets.Empresa_id = Empresa_id;
                tickets.Descripcion_problema = Descripcion_problema;
                tickets.Usuario_asignado_id = Usuario_asignado_id;
                tickets.Modalidad_id = Modalidad_id;
                tickets.Status_id = Status_id;
                tickets.Fecha_creacion = Fecha_creacion;
                context.TTickets.Add(tickets);
                context.SaveChanges();
                //envio de correos de notificacion a encargados
                MailConfig mailSender = new MailConfig();
                string message = "" +
                    "<table>" +
                        "<tr>" +
                            "<td><img src='cid:addfile'></td>" +
                            "<td><h3 style='align-items: center; text-align: inherit;'> Se agregó un nuevo ticket de soporte.</td>" +
                        "</tr>" +
                    "</table>" +
                    "<hr><br>" +
                    "<table>" +
                        "<tr>" +
                            "<td><img src='cid:bell'></td>" +
                            "<td><h4 style='color: maroon;'>&nbsp;Prioridad:&nbsp;</h4></td>" +
                            "<td>2</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><img src='cid:user'></td>" +
                            "< td><h4 style='color: maroon;'>&nbsp;Usuario:&nbsp;</h4></td>" +
                            "< td>oscarm</td>" +
                        "</tr>" +
                        "<tr>" +
                            "< td><img src='cid:category'></td>" +
                            "<td><h4 style='color: maroon;'>&nbsp;Tipo Soporte:&nbsp;</h4></td>" +
                            "<td>Papeleria</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><img src='cid:bubble'></td>" +
                            "<td><h4 style='color: maroon;'>&nbsp;Descripción:&nbsp;</h4></td>" +
                            "<td>Se solicitan 2 paquetes de hojas de 500</td>" +
                        "</tr>" +
                    "</table>" +
                    "<br><br>" +
                    "<div><img width='35%' src='cid:logo_app'></div>" +
                    "<p><small>Aplicación de soporte tecnico RACI TI</small></p>" +
                    "<hr>" +
                    "<p><small>Este es un correo electrónico automático únicamente informativo, no responder notificaciones dentro del mismo.</small></p>";

                bool mailOk = false;
                mailOk = mailSender.CustomMail("oscarm@raciti.com.mx", "Nuevo ticket HELP DESK", message);

                if (mailOk) {
                    Console.WriteLine("Enviado");
                }

                return Ok(tickets);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        //[HttpPost("{}")]
        //////////////////
        /// PUT
        //////////////////
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TTickets tickets)
        {
            if (tickets.IdTicket == id)
            {
                context.Entry(tickets).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //////////////////
        /// VOID - DELETE
        //////////////////
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TTickets tickets = context.TTickets.FirstOrDefault(p => p.IdTicket == id);
        }
    }
}
