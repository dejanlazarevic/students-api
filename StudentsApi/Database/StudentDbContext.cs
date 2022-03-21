using Microsoft.EntityFrameworkCore;
using StudentsApi.Models;

namespace StudentsApi.Database
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options): base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
