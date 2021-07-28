using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_RESTFULL_HELPDESK_APP.Controllers.Conexion;
using API_RESTFULL_HELPDESK_APP.Controllers.Models;
using API_RESTFULL_HELPDESK_APP.Models;

namespace API_RESTFULL_HELPDESK_APP.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ModalidadesController : Controller
    {
        private readonly ConexionApp context;

        public ModalidadesController(ConexionApp context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<CModalidades> Get()
        {
            return context.CModalidades.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                ModalidadesDao Dao = new ModalidadesDao();
                List<CModalidades> modalidades = new List<CModalidades>();
                modalidades = Dao.sp_CModalidades_getModalidades(id);

                return Ok(modalidades.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post( CModalidades model)
        {
            ModalidadesDao Dao = new ModalidadesDao();
            Respuestas respuestas = new Respuestas();
            respuestas = Dao.sp_CModalidades_insertModalidades(model);

            return Ok(respuestas);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CModalidades modalidad)
        {
            if (modalidad.Id == id)
            {
                context.Entry(modalidad).State = EntityState.Modified;
                context.SaveChanges();
                return Ok(modalidad);
            }
            else
            {
                return BadRequest(modalidad);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                CModalidades modalidades = context.CModalidades.FirstOrDefault(p => p.Id == id);
                return Ok(modalidades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

    }
}
