using API_RESTFULL_HELPDESK_APP.Controllers.Models;
using API_RESTFULL_HELPDESK_APP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace API_RESTFULL_HELPDESK_APP.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ListController : Controller
    {
        [HttpGet("{Status_id}")]
        public ActionResult GetTicketsByStatus( string Status_id)
        {
            try
            {
                TTicketsDao Dao = new TTicketsDao();
                List<DetalleTickets> tickets = Dao.sp_Tickets_getTicketsByStatus(Status_id);
                return Ok(tickets);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
