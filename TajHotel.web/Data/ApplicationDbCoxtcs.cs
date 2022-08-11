using Microsoft.EntityFrameworkCore;
using TajHotel.web.Models;
using TajHotel.Models;
namespace TajHotel.web.Data
{
    public class ApplicationDbContext : DbContext
    {
        
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<FoodCategory> FoodCategories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Food> Foods { get; set; }

        public DbSet<PaymentDetail> PaymentDetail { get; set; }
    }
}
