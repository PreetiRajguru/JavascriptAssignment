using MatterAssignment.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MatterAssignment.Data.Context
{
    public class MatterAssignmentDbContext : DbContext
    {
        public MatterAssignmentDbContext()
        {

        }
        public MatterAssignmentDbContext(DbContextOptions<MatterAssignmentDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Matter> Matters { get; set; }
        public DbSet<Attorney> Attorneys { get; set; }
        public DbSet<RoleMaster> RoleMaster { get; set; }
        public DbSet<AttorneyRole> AttorneyRole { get; set; }
        public DbSet<JurisdictionMaster> JurisdictionMaster { get; set; }
        public DbSet<Invoice> Invoices { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=MattersAssignment;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //one to many
            modelBuilder.Entity<Client>()
                    .HasMany(e => e.Matters)
                    .WithOne(e => e.Client)
                    .HasForeignKey(e => e.ClientId)
                    .IsRequired();

            modelBuilder.Entity<Attorney>()
                   .HasMany(e => e.Matters)
                   .WithOne(e => e.Attorney)
                   .HasForeignKey(e => e.BillingAttorneyId)
                   .IsRequired();

            modelBuilder.Entity<Attorney>()
                   .HasMany(e => e.Matters)
                   .WithOne(e => e.Attorney)
                   .HasForeignKey(e => e.ResponsibleAttorneyId)
                   .IsRequired();

            modelBuilder.Entity<Attorney>()
                   .HasMany(e => e.AttorneyRoles)
                   .WithOne(e => e.Attorney)
                   .HasForeignKey(e => e.AttorneyId)
                   .IsRequired();

            modelBuilder.Entity<RoleMaster>()
                   .HasMany(e => e.AttorneyRoles)
                   .WithOne(e => e.RoleMaster)
                   .HasForeignKey(e => e.AttorneyId)
                   .IsRequired();

            modelBuilder.Entity<Matter>()
                   .HasMany(e => e.Invoices)
                   .WithOne(e => e.Matter)
                   .HasForeignKey(e => e.MatterId)
                   .IsRequired();

            modelBuilder.Entity<Attorney>()
                 .HasMany(e => e.Invoices)
                 .WithOne(e => e.Attorney)
                 .HasForeignKey(e => e.AttorneyId)
                 .IsRequired();

            //one to one
            modelBuilder.Entity<JurisdictionMaster>()
                    .HasOne(e => e.Attorney)
                    .WithOne(e => e.Jurisdiction)
                    .HasForeignKey<Attorney>(e => e.JurisdictionId)
      .             IsRequired();

            modelBuilder.Entity<JurisdictionMaster>()
                   .HasOne(e => e.Matter)
                   .WithOne(e => e.Jurisdiction)
                   .HasForeignKey<Matter>(e => e.JurisdictionId)
                   .IsRequired();
        }
    }
}
