using Asp.netCore_Palma_RealState.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Asp.netCore_Palma_RealState.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<User_Model> User_Model { get; set; }
        public DbSet<T_estate> T_estate { get; set; }
        public DbSet<T_category> T_category { get; set; }


    }
}
