using API_RESTFULL_HELPDESK_APP.Controllers.Models;
using API_RESTFULL_HELPDESK_APP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_RESTFULL_HELPDESK_APP.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        [HttpPost]
        public ActionResult PostSaveToken(NewToken token)
        {
            try 
            {

                UsuariosDao Dao = new UsuariosDao();
                Respuestas respuestas = Dao.sp_TUsuarios_SaveToken(token);
                return Ok(respuestas);

            } 
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }
        }
    }
}
