using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NextTechStudentManagement.Models;

namespace NextTechStudentManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

    }
}
