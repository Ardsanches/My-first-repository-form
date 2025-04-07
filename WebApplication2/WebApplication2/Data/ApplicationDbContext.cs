using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

/* ApplicationDbContext is the class that manages the database connection and CRUD operations for FormData
It inherits from DbContext provided by Entity Framework to interact with the database
The DbSet<FormData> property represents the FormData table in the database */

namespace WebApplication2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FormData> FormData { get; set; }
    }
} 
