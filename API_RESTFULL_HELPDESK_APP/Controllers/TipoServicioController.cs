using System;
using System.Collections.Generic;
using System.Linq;
using API_RESTFULL_HELPDESK_APP.Controllers.Conexion;
using API_RESTFULL_HELPDESK_APP.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API_RESTFULL_HELPDESK_APP.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TipoServicioController : ControllerBase
    {
        private readonly ConexionApp context;

        public TipoServicioController(ConexionApp context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<CTipoServicio> Get()
        {
            return context.CTipoServicio.ToList();
        }

        [HttpGet("{id}")]
        public CTipoServicio Get(int id)
        {
            CTipoServicio tipoServicio = context.CTipoServicio.FirstOrDefault(p => p.IdTipoServicio == id);
            return tipoServicio;
        }

        [HttpPost]
        public ActionResult Post([FromBody] int IdTipoServicio, string Nombre, int Cancelado)
        {
            CTipoServicio serv = new CTipoServicio();
            serv.IdTipoServicio = IdTipoServicio;
            serv.Nombre = Nombre;
            serv.Cancelado = Cancelado;
            try
            {
                context.CTipoServicio.Add(serv);
                context.SaveChanges();
                return Ok(serv);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CTipoServicio tipoServicio)
        {
            if (tipoServicio.IdTipoServicio == id)
            {
                context.Entry(tipoServicio).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CTipoServicio tipoServicio = context.CTipoServicio.FirstOrDefault(p => p.IdTipoServicio == id);
        }
    }
}
