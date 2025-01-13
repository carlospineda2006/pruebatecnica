using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Shared.Models
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;

        public DateTime? FechaNacimiento { get; set; }
        public DateTime? FechaIngreso { get; set; }

        public string Afp { get; set; } = string.Empty;

        public string Cargo { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 6)")]
        public Decimal Sueldo { get; set; }

        public bool FlagEliminado { get; set; } = false;
    }
}
