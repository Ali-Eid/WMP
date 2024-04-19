using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WMBProject.Data.Entities;

namespace WMBProject.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<User> User { get; set; }

        public virtual ICollection<IdentityUserClaim<long>> Claims { get; set; } = null!;
        public virtual ICollection<IdentityUserLogin<long>> Logins { get; set; } = null!;
        public virtual ICollection<IdentityUserToken<long>> Tokens { get; set; } = null!;
        public virtual ICollection<IdentityRole<long>> AspNetRoles { get; set; } = null!;


        public DbSet<Artist> Artist { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Invoice> Invoice { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<Song> Song { get; set; }

        public DbSet<SongType> SongType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(a => a.UserInvoices).WithOne(x => x.User).HasForeignKey(x=>x.UserId);

            });
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasOne(a => a.User).WithMany(x => x.UserInvoices).HasForeignKey(x=>x.UserId);
            });

            modelBuilder.Entity<Order>(entity => {

                entity.HasOne(x => x.Song).WithMany(y => y.Order).HasForeignKey(x=>x.SongId);
                entity.HasOne(x => x.Invoice ).WithMany(y => y.Order).HasForeignKey(x => x.InvoiceId);

            });

            modelBuilder.Entity<Artist>(entity => {

                entity.HasMany(x => x.Songs).WithOne(y => y.Artist).HasForeignKey(x=>x.ArtistId);
                entity.HasOne(x => x.Country).WithMany(y => y.Artists).HasForeignKey(x => x.CountryId);


            });

            modelBuilder.Entity<Country>(entity => {

                entity.HasMany(x => x.Artists).WithOne(y => y.Country).HasForeignKey(x=>x.CountryId);
            });

            modelBuilder.Entity<Song>(entity => {

                entity.HasOne(x => x.Artist).WithMany(y => y.Songs).HasForeignKey(x=>x.ArtistId);

                entity.HasOne(x => x.Type).WithMany(y => y.Songs).HasForeignKey(x=>x.TypeId);

            });

            modelBuilder.Entity<SongType>(entity => {

                entity.HasMany(x => x.Songs).WithOne(y => y.Type).HasForeignKey(x=>x.TypeId);

            });
        }

    }
}

