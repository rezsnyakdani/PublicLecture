using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PublicLecture.Entities.Models;

namespace PublicLecture.Data
{
    public class PublicLectureContext : IdentityDbContext
    {
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<University> Universities { get; set; }


        public PublicLectureContext(DbContextOptions<PublicLectureContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecture>()
                .HasMany(l => l.Participants)
                .WithOne(p => p.Lecture)
                .HasForeignKey(p => p.LectureId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<University>()
                .HasMany(u => u.Lectures)
                .WithOne(l => l.University)
                .HasForeignKey(l => l.UniversityId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
