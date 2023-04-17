using EntityFrameworkLab1.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLab1.Data
{
    public class VacationDbContext : DbContext
    {
        public VacationDbContext(DbContextOptions<VacationDbContext> options) : base(options)
        {

        }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
