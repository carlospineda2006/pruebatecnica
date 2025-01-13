using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Server.Data;
using PruebaTecnica.Shared.Models;
using PruebaTecnica.Shared.Wrappers;

namespace PruebaTecnica.Server.Services.EmpleadoService
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly DataContext _context;
        public EmpleadoService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<Empleado>> ActualizarEmpleado(Empleado dto)
        {
            var dbEmpleado = await _context.Empleado.FirstOrDefaultAsync(x => x.EmpleadoId == dto.EmpleadoId);

            if (dbEmpleado == null)
            {
                return new ServiceResponse<Empleado>
                {
                    Success = false,
                    Message = "No se encontro el empleado."
                };
            }

            try
            {
                dbEmpleado.Nombres = dto.Nombres;
                dbEmpleado.Apellidos = dto.Apellidos;
                dbEmpleado.FechaNacimiento = dto.FechaNacimiento;
                dbEmpleado.FechaIngreso = dto.FechaIngreso;
                dbEmpleado.Afp = dto.Afp;
                dbEmpleado.Cargo = dto.Cargo;
                dbEmpleado.Sueldo = dto.Sueldo;

                await _context.SaveChangesAsync();

                return new ServiceResponse<Empleado>
                {
                    Data = dto,
                    Message = "El emplealdo fue actualizado."
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Empleado>
                {
                    Data = dto,
                    Success = false,
                    Message = $"A ocurrido un error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<Empleado>> CrearEmpleado(Empleado dto)
        {
            try
            {
                var result = _context.Empleado.Add(dto);

                var saveResult = await _context.SaveChangesAsync();

                return new ServiceResponse<Empleado>
                {
                    Data = dto,
                    Message = @"Empleado creado.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<Empleado>
                {
                    Data = dto,
                    Message = ex.InnerException.Message,
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Empleado>> EliminarEmpleado(int empleadoId)
        {
            var dbEmpleado = await _context.Empleado.FirstOrDefaultAsync(x => x.EmpleadoId == empleadoId);

            if (dbEmpleado == null)
            {
                return new ServiceResponse<Empleado>
                {
                    Success = false,
                    Message = "No se encontro el empleado."
                };
            }

            try
            {
                dbEmpleado.FlagEliminado = true;
                
                await _context.SaveChangesAsync();

                return new ServiceResponse<Empleado>
                {
                    Data = dbEmpleado,
                    Message = "El emplealdo fue eliminado exitosamente."
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Empleado>
                {
                    Data = dbEmpleado,
                    Success = false,
                    Message = $"A ocurrido un error: {e.Message}"
                };
            }
        }

        public async Task<ServiceResponse<Empleado>> GetEmpleadoById(int empleadoId)
        {
            ServiceResponse<Empleado> response = new();

            var empleado = await _context.Empleado.FirstOrDefaultAsync(x => x.EmpleadoId == empleadoId);

            if (empleado == null)
            {
                response.Success = false;
                response.Message = "No se encontro el empleado";
                return response;
            }

            response.Data = empleado;
            response.Message = $"El empleado se encontro.";
            return response;
        }

        public async Task<ServiceResponse<List<Empleado>>> GetEmpleados()
        {
            var response = new ServiceResponse<List<Empleado>>();

            var registrosTotales = await _context.Empleado.CountAsync();


            if (registrosTotales == 0)
            {
                response.Success = true;
                response.Message = "No se encontraron empleados.";
                return response;
            }

            var empleados = await _context.Empleado
                                .Where(x => x.FlagEliminado == false)
                                .OrderBy(x => x.Apellidos)
                                .ToListAsync();

            response.Data = empleados;
            response.Success = true;
            response.Message = "Empelados encontrados con éxito.";

            return response;
        }
    }
}
