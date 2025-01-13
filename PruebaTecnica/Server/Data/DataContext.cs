using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Shared.Models;

namespace PruebaTecnica.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Empleado> Empleado { set; get; }
    }
}
