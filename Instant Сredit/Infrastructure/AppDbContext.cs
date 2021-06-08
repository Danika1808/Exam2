using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public AppDbContext()
        { }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Credit> Credits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Borrower>().OwnsOne(x => x.FullName, y =>
            {
                y.Property(x => x.FirstName).HasColumnName("FirstName");
                y.Property(x => x.LastName).HasColumnName("LastName");
                y.Property(x => x.MiddleName).HasColumnName("MiddleName");
            });
            modelBuilder.Entity<Borrower>().OwnsOne(x => x.Passport, y =>
            {
                y.Property(x => x.DateOfIssue).HasColumnName("DateOfIssue");
                y.Property(x => x.IssuedBy).HasColumnName("IssuedBy");
                y.Property(x => x.Number).HasColumnName("Number"); 
                y.Property(x => x.Residency).HasColumnName("Residency"); 
                y.Property(x => x.Series).HasColumnName("Series");
                y.Property(x => x.SubdivisionCode).HasColumnName("SubdivisionCode");
            });
        }
    }
}
