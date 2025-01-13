using PruebaTecnica.Shared.Models;
using PruebaTecnica.Shared.Wrappers;

namespace PruebaTecnica.Client.Services.EmpleadoService
{
    public interface IEmpleadoService
    {
        event Action? OnChange;
        public string Mensaje { get; set; }
        List<Empleado> Empleados { get; set; }
        Task<ServiceResponse<Empleado>> CrearEmpleado(Empleado dto);
        Task<ServiceResponse<Empleado>> ActualizarEmpleado(Empleado dto);
        Task<ServiceResponse<Empleado>> EliminarEmpleado(int empleadoId);
        Task GetEmpleados();
        Task<ServiceResponse<Empleado>> GetEmpleadoById(int empleadoId);
    }
}
