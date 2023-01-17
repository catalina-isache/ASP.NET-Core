using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class ProiectContext: DbContext
    {
        /*public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentInCourse> StudentsInCourse { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<CourseGrade> CoursesGrades { get; set; }
        */

        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<StudentInCourse>()
                  .HasKey(sc => new { sc.StudentId, sc.CourseId });
           
            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentsInCourses)
                .WithOne(sic => sic.Student)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<StudentInCourse>()
                        .HasOne(sc => sc.Student)
                        .WithMany(s => s.StudentsInCourses)
                        .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentInCourse>()
                        .HasOne(sc => sc.Course)
                        .WithMany(c => c.StudentsInCourses)
                        .HasForeignKey(sc => sc.CourseId);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teacher);

            modelBuilder.Entity<CourseGrade>()
                .HasOne(cg => cg.StudentInCourse)
                .WithOne(c => c.StudentCourseGrade)
                .HasForeignKey<StudentInCourse>(g => g.StudentCourseGradeId);
            */
            base.OnModelCreating(modelBuilder);
        }
    }
}
