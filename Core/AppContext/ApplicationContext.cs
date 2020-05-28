using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext( DbContextOptions options ) : base(options) 
        {

        }

        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentDelivery> documentDeliveries { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserStudent> UserStudents { get; set; }
        public DbSet<UserTeacher> UserTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Assignment>().Property(x => x.Created)
                                        .HasDefaultValue(DateTime.Now);
            builder.Entity<Classroom>().Property(x => x.Created)
                                       .HasDefaultValue(DateTime.Now);
            builder.Entity<Delivery>().Property(x => x.Created)
                                      .HasDefaultValue(DateTime.Now);
            builder.Entity<Document>().Property(x => x.Created)
                                      .HasDefaultValue(DateTime.Now);
            builder.Entity<DocumentDelivery>().Property(x => x.Created)
                                      .HasDefaultValue(DateTime.Now);
            builder.Entity<Post>().Property(x => x.Created)
                                  .HasDefaultValue(DateTime.Now);
            builder.Entity<Role>().Property(x => x.Created)
                                  .HasDefaultValue(DateTime.Now);
            builder.Entity<UserStudent>().Property(x => x.Created)
                                        .HasDefaultValue(DateTime.Now);
            builder.Entity<UserTeacher>().Property(x => x.Created)
                                         .HasDefaultValue(DateTime.Now);
        }

    }
}
