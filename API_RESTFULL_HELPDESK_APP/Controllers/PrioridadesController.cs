using API_RESTFULL_HELPDESK_APP.Controllers.Conexion;
using API_RESTFULL_HELPDESK_APP.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RESTFULL_HELPDESK_APP.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class PrioridadesController : Controller
    {
        private readonly ConexionApp context;

        public PrioridadesController(ConexionApp context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Prioridades> Get()
        {
            return context.CPrioridad.ToList();
        }
    }
}
