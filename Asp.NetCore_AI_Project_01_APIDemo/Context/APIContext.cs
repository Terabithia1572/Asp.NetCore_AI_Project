using Asp.NetCore_AI_Project_01_APIDemo.Entites;
using Microsoft.EntityFrameworkCore;

namespace Asp.NetCore_AI_Project_01_APIDemo.Context
{
    public class APIContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;initial catalog=AIProjectDB;Integrated Security=true;trustservercertificate=true");
        }
        public DbSet<Customer> Customers { get; set; } //Customer bizim Entities Çoğul hali İse Veritabanına yansıyacak isim (Customers)
    }
}
