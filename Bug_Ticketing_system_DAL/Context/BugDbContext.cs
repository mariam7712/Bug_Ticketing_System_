using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bug_Ticketing_System_DAL
{
    public class BugDbContext : IdentityDbContext<User>
    {
        public BugDbContext(DbContextOptions<BugDbContext> options) : base(options)
        {
        }

        public DbSet<Bug> Bugs { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<BugAssignment> BugAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call base method for Identity configuration

            modelBuilder.Entity<BugAssignment>()
                .HasKey(ba => new { ba.BugId, ba.UserId });

            modelBuilder.Entity<BugAssignment>()
                .HasOne(ba => ba.User)
                .WithMany(u => u.BugAssignments)
                .HasForeignKey(ba => ba.UserId).HasPrincipalKey(u => u.Id); ;

            modelBuilder.Entity<BugAssignment>()
                .HasOne(ba => ba.Bug)
                .WithMany(b => b.BugAssignments)
                .HasForeignKey(ba => ba.BugId);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Bugs)
                .WithOne(b => b.Project)
                .HasForeignKey(b => b.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bug>()
                .HasMany(b => b.Attachements)
                .WithOne(a => a.Bug)
                .HasForeignKey(a => a.BugId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(p => p.Id)
                      .HasColumnType("uniqueidentifier") // Set column type
                      .IsRequired() // Make it non-nullable
                      .HasDefaultValueSql("NEWID()"); // Use NEWID() to generate unique GUIDs
            });
        }
    }
}
