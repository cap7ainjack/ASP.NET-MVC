namespace KidsAcademy.Data
{
    using KidsAcademy.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class KidsAcademyContext : IdentityDbContext<ApplicationUser>
    {

        public KidsAcademyContext()
            : base("name=KidsAcademy", throwIfV1Schema: false)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<SubCourse> SubCourses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Parent> Parents { get; set; }

        public static KidsAcademyContext Create()
        {
            return new KidsAcademyContext();
        }

    }
}