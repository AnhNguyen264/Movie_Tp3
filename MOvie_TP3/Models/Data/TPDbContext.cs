using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace TP2.Models.Data
{
    public class TPDbContext: IdentityDbContext
    {
        public TPDbContext(DbContextOptions<TPDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.SetEntityRelationships();
            modelBuilder.GenerateData();

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Enfant> Enfants { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Objectives> Objectives { get; set; }
        public DbSet<Vendeur> Vendeurs { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
