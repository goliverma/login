using Microsoft.EntityFrameworkCore;
using models;

namespace test.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Register> Registers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Register>().HasData(
                new Register{
                    Id=1,
                    UserName="GauravVerma", 
                    UserEmail="gaurav@gmail.com", 
                    Password="password0", 
                    Status="Active",
                    Role="Admin"
                }
            );
        }
    }
}