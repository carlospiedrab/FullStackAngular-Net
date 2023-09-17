using API.Errores;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entidades;

namespace API.Controllers
{
    public class ErrorTestController : BaseApiController
    {
        private readonly ApplicationDbContext _db;

        public ErrorTestController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetNotAuthorize()
        {
            return "No Autorizado";
        }

        
        [HttpGet("not-found")]
        public ActionResult<Usuario> GetNotFound()
        {
            var objeto = _db.Usuarios.Find(-1);
            if (objeto == null) return NotFound(new ApiErrorResponse(404));
            return objeto;
        }

        
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var objeto = _db.Usuarios.Find(-1);
            var objetoString = objeto.ToString();
            return objetoString;

        }

        
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest(new ApiErrorResponse(400));
        }

    }
}
