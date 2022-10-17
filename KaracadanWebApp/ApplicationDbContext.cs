using KaracadanWebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KaracadanWebApp
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Personels> Personels { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Personels>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SicilNo)
                    .IsRequired(false)
                    .HasMaxLength(100);

                entity.Property(e => e.CardNumber)
                    .IsRequired(false)
                    .HasMaxLength(100);


                entity.Property(e => e.Email)
                    .IsRequired(false)
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired(false)
                    .HasMaxLength(100);

                entity.Property(e => e.FirmName)
                    .IsRequired(false)
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired(false)
                    .HasMaxLength(100);
            });

            base.OnModelCreating(builder);
        }
    }
}
