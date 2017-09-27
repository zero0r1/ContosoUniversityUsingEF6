using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        const string _nameOrConnectionString = "SchoolContext";

        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Person> People { get; set; }

        public SchoolContext() : base(_nameOrConnectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new InstructorConfiguration());

            //This code instructs Entity Framework to use stored procedures for insert, update, and delete operations on the Department entity.
            modelBuilder.Entity<Department>().MapToStoredProcedures();
        }


        public class CourseConfiguration : EntityTypeConfiguration<Course>
        {
            public CourseConfiguration()
            {
                //modelBuilder.Entity<Course>()
                //    .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                //    .Map(t => t.MapLeftKey("CourseID")
                //        .MapRightKey("InstructorID")
                //        .ToTable("CourseInstructor"));

                HasMany(c => c.Instructors).WithMany(i => i.Courses)
                    .Map(t => t.MapLeftKey("CourseID")
                     .MapRightKey("InstructorID")
                     .ToTable("CourseInstructor"));
            }
        }

        public class InstructorConfiguration : EntityTypeConfiguration<Instructor>
        {
            public InstructorConfiguration()
            {
                //modelBuilder.Entity<Instructor>()
                //    .HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);

                HasOptional(p => p.OfficeAssignment).WithRequired(p => p.Instructor);
            }
        }
    }
}