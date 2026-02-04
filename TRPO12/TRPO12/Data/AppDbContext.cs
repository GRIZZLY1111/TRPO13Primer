using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRPO12.Models;

namespace TRPO12.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students {  get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Group> Groups { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=SchoolDB_Solihov; User Id = student_06; Password = student_06; TrustServerCertificate = True;");
            //optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SchoolDB;Trusted_Connection=True; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()// отношение один-к-одному
            .HasOne(s => s.Passport)
            .WithOne(ps => ps.Student)
            .HasForeignKey<Passport>(ps => ps.StudentId);

            modelBuilder.Entity<Group>() // отношение один-ко-многим
                                         .HasMany(g => g.Students)
                                         .WithOne(s => s.Group)
                                         .HasForeignKey(s => s.GroupId);
        }
    }
}
