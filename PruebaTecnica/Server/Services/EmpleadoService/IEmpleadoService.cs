using PruebaTecnica.Shared.Models;
using PruebaTecnica.Shared.Wrappers;

namespace PruebaTecnica.Server.Services.EmpleadoService
{
    public interface IEmpleadoService
    {
        Task<ServiceResponse<List<Empleado>>> GetEmpleados();
        Task<ServiceResponse<Empleado>> CrearEmpleado(Empleado dto);
        Task<ServiceResponse<Empleado>> ActualizarEmpleado(Empleado dto);
        Task<ServiceResponse<Empleado>> EliminarEmpleado(int empleadoId);
        Task<ServiceResponse<Empleado>> GetEmpleadoById(int empleadoId);
    }
}
