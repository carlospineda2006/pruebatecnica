using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Server.Services.EmpleadoService;
using PruebaTecnica.Shared.Models;
using PruebaTecnica.Shared.Wrappers;

namespace PruebaTecnica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        [HttpPost]
        [Route("CrearEmpleado")]
        public async Task<ActionResult<Empleado>> CrearEmpleado(Empleado empleado)
        {
            var response = await _empleadoService.CrearEmpleado(empleado);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut]
        [Route("ActualizarEmpleado")]
        public async Task<ActionResult<ServiceResponse<Empleado>>> ActualizarProducto(Empleado dto)
        {
            var response = await _empleadoService.ActualizarEmpleado(dto);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpPut]
        [Route("EliminarEmpleado")]
        public async Task<ActionResult<ServiceResponse<Empleado>>> EliminarEmpleado(int empleadoId)
        {
            var response = await _empleadoService.EliminarEmpleado(empleadoId);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }

        [HttpGet]
        [Route("GetEmpleados")]
        public async Task<ActionResult<ServiceResponse<List<Empleado>>>> GetEmpleados()
        {
            var response = await _empleadoService.GetEmpleados();

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetEmpleadoById")]
        public async Task<ActionResult<ServiceResponse<Empleado>>> GetEmpleadoById([FromQuery] int empleadoId)
        {
            var response = await _empleadoService.GetEmpleadoById(empleadoId);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest();
        }
    }
}
