using BLL.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using System.Net;

namespace API.Controllers
{
    [Authorize(Policy = "AdminAgendadorRol")]
    public class MedicoController : BaseApiController
    {
        private readonly IMedicoServicio _medicoServicio;
        private ApiResponse _response;

        public MedicoController(IMedicoServicio medicoServicio)
        {
            _medicoServicio = medicoServicio;
            _response = new();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                _response.Resultado = await _medicoServicio.ObtenerTodos();
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;
            }
            return Ok(_response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(MedicoDto modeloDto)
        {
            try
            {
                await _medicoServicio.Agregar(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;   
            }
            return Ok(_response);
        }

        [HttpPut]
        public async Task<IActionResult> Editar(MedicoDto modeloDto)
        {
            try
            {
                await _medicoServicio.Actualizar(modeloDto);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode = HttpStatusCode.BadRequest;   
            }
            return Ok(_response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                await _medicoServicio.Remover(id);
                _response.IsExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.Mensaje = ex.Message;
                _response.StatusCode= HttpStatusCode.BadRequest;    
            }
            return Ok(_response);   
        }

    }
}
