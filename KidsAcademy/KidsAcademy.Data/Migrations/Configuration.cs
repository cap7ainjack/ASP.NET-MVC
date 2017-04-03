namespace KidsAcademy.Data.Migrations
{
    using KidsAcademy.Models.EntityModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KidsAcademyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(KidsAcademyContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Parent"))
            {
                var role = new IdentityRole();
                role.Name = "Parent";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Teacher"))
            {
                var role = new IdentityRole();
                role.Name = "Teacher";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Student"))
            {
                var role = new IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);
            }


            context.Courses.AddOrUpdate(course => course.Name, new Course[]
            {
                new Course()
                {
                    Name = "Mathematics 1st grade",
                    Description = "In Grade 1, instructional time should focus on four critical areas: (1) developing understanding of addition, subtraction, and strategies for addition and subtraction within 20; (2) developing understanding of whole number relationships and place value, including grouping in tens and ones; (3) developing understanding of linear measurement and measuring lengths as iterating length units; and (4) reasoning about attributes of, and composing and decomposing geometric shapes.",
                    Duration = 3                    
                },

                new Course()
                {
                    Name = "Mathematics 2nd grade",
                    Description = "In Grade 2, instructional time should focus on four critical areas: (1) extending understanding of base-ten notation; (2) building fluency with addition and subtraction; (3) using standard units of measure; and (4) describing and analyzing shapes.",
                    Duration = 3
                },
                
                new Course()
                {
                    Name = "Mathematics 3rd grade",
                    Description = "In Grade 3, instructional time should focus on four critical areas: (1) developing understanding of multiplication and division and strategies for multiplication and division within 100; (2) developing understanding of fractions, especially unit fractions (fractions with numerator 1); (3) developing understanding of the structure of rectangular arrays and of area; and (4) describing and analyzing two-dimensional shapes.",
                    Duration = 4
                },

                new Course()
                {
                    Name="Grammar 1st grade",
                    Description = "First grade is where most kids will get the most important components of their language arts education. It's also the time when language is most fun, full of clapping, singing, and rhyming.",
                    Duration = 4
                },

                new Course()
                {
                    Name = "Grammar 2nd Grade",
                    Description = "Kids will learn about adjectives, verbs, and more in these second grade grammar worksheets which feature colorful designs, clear instructions, and beautiful illustrations. These second grade grammar worksheets help your child develop both writing and speaking skills, and help her in other subjects as well.",
                    Duration = 2
                }

            });
        }
    }
}
