using E_MedicineBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace E_MedicineBackend.EntityFrameWork
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Medicines> Medicines { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Cart> Cart { get; set; }
    }
}
