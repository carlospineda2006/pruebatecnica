using PruebaTecnica.Client.Utils;
using PruebaTecnica.Shared.Models;
using PruebaTecnica.Shared.Wrappers;
using System.Net.Http.Json;

namespace PruebaTecnica.Client.Services.EmpleadoService
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient _http;

        public List<Empleado> Empleados { get; set; } = new List<Empleado>();
        public string Mensaje { get; set; }

        public event Action? OnChange;

        public EmpleadoService(HttpClient http)
        {
            _http = http;
        }
        public async Task<ServiceResponse<Empleado>> CrearEmpleado(Empleado dto)
        {
            var response = await _http.PostAsJsonAsync($"{ApiUrls.Empleado.Crear}", dto);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Empleado>>();
            return result;
        }

        public async Task GetEmpleados()
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<List<Empleado>>>($"{ApiUrls.Empleado.Get}");

            if (response != null && response.Data != null)
            {
                Empleados.Clear();
                Empleados = response.Data;
                Mensaje = response.Message;
            }

            OnChange?.Invoke();
        }

        public async Task<ServiceResponse<Empleado>> ActualizarEmpleado(Empleado dto)
        {
            var response = await _http.PutAsJsonAsync($"{ApiUrls.Empleado.Actualizar}", dto);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Empleado>>();
            return result!;
        }

        public async Task<ServiceResponse<Empleado>> GetEmpleadoById(int empleadoId)
        {
            var response = await _http.GetFromJsonAsync<ServiceResponse<Empleado>>($"{ApiUrls.Empleado.GetById}?empleadoId={empleadoId}");

            return response!;
        }

        public async Task<ServiceResponse<Empleado>> EliminarEmpleado(int empleadoId)
        {
            var response = await _http.PutAsJsonAsync($"{ApiUrls.Empleado.Eliminar}?empleadoId={empleadoId}", empleadoId);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Empleado>>();
            return result!;
        }
    }
}
