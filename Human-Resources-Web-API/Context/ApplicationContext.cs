using Human_Resources_Web_API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Human_Resources_Web_API.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options, IConfiguration configuration) :
            base(options)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        public DbSet<Employee> Employees { get; set; }
        public DbSet<HumanResourceData> HumanResourcesData { get; set; }
        public DbSet<EmployeeLeft> EmployeesLeft { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(b => b.HumanResourceData)
                .WithOne(i => i.Employee)
                .HasForeignKey<HumanResourceData>(b => b.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}