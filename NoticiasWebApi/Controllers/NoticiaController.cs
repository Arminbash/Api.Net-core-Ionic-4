using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasWebApi.Models;
using NoticiasWebApi.Services;


namespace NoticiasWebApi.Controllers
{
    [Route("api/noticias")]
    [ApiController]
    public class NoticiaController : ControllerBase 
    {
        private readonly NoticiaServices _noticiaServicio;
        public NoticiaController(NoticiaServices noticiaServicio)
        {
            _noticiaServicio = noticiaServicio;
        }

        public IActionResult Prueba()
        {
            return Ok("Funciona");
        }
        [Route("VerNoticias")]
        public IActionResult verNoticias()
        {
            var _resultado = _noticiaServicio.verListadoTodasLasNoticias();
            return Ok(_resultado);
        }
        [Route("Agregar")]
        [HttpPost]
        public IActionResult Agregar([FromBody] Noticia NoticiaAgregar)
        {
            if (_noticiaServicio.Agregar(NoticiaAgregar))
                return Ok();
            else
                return BadRequest();
        }

        [Route("Editar")]
        [HttpPut]
        public IActionResult Editar([FromBody] Noticia NoticiaEditar)
        {
            if (_noticiaServicio.Editar(NoticiaEditar))
                return Ok();
            else
                return BadRequest();

        }

        [Route("Eliminar/{noticiaID}")]
        public IActionResult Eliminar(int noticiaID)
        {
            if (_noticiaServicio.Eliminar(noticiaID))
                return Ok();
            else
                return BadRequest();

        }

         
        [Route("ListadoAutores")]
        public IActionResult ListadoAutores()
        {
            return Ok( _noticiaServicio.listadoDeAutores());
        }
    }
}