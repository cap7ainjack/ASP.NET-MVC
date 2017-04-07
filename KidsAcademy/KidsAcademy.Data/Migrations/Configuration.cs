namespace KidsAcademy.Data.Migrations
{
    using KidsAcademy.Models.EntityModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
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
                    Name = "Първи клас",
                    SubCourses = new HashSet<SubCourse>()
                    {
                        new SubCourse()
                        {
                            Name = "Математика за първи клас",
                            Description = "Несъмнено едно от предизвикателствата пред малките ученици е разбирането и решаването на текстови задачи.Ще се научат да съставят текстови задачи, да подреждат изречения, така че да се получи текстова задача и ще развият умения за решаването им",
                            HoursPerWeek = 6
                        },

                        new SubCourse()
                        {
                            Name="Граматика за първи клас",
                            Description = "Включва теория и много практически упражнения, изключително полезни за обогатяване на езиковата култура на първокласниците.",
                            HoursPerWeek = 7
                        },

                        new SubCourse()
                        {
                            Name= "Четене за първи клас",
                            Description = "Предназначено за овладяване техниките на четене от първокласниците. Предложеният от авторите новаторски, нетрадиционен и атрактивен подход при представяне на съдържанието улеснява детето в учебната му дейност, превръща ученето и четенето в забавно и желано занимание.",
                            HoursPerWeek = 5
                        },

                        new SubCourse()
                        {
                            Name= "Музика за първи клас",
                            Description = "Намерена е логическа връзка на творби от българския фолклор, на произведения от класически и съвременни автори. Изпълнението на песните с инструментални съпроводи доставя радост и желание за индивидуална изява, развива детската артистичност, прави певческата дейност изключително приятна и развлекателна.",
                            HoursPerWeek = 4
                        }
                    }
                },

                new Course()
                {
                    Name = "Втори клас",
                    SubCourses = new HashSet<SubCourse>()
                    {
                        new SubCourse()
                        {
                            Name = "Математика за втори клас",
                            Description = "Несъмнено едно от предизвикателствата пред малките ученици е разбирането и решаването на текстови задачи.Ще се научат да съставят текстови задачи, да подреждат изречения, така че да се получи текстова задача и ще развият умения за решаването им",
                            HoursPerWeek = 6
                        },

                        new SubCourse()
                        {
                            Name="Граматика за втори клас",
                            Description = "Включва теория и много практически упражнения, изключително полезни за обогатяване на езиковата култура на първокласниците.",
                            HoursPerWeek = 7
                        },

                        new SubCourse()
                        {
                            Name= "Четене за втори клас",
                            Description = "Предназначено за овладяване техниките на четене от първокласниците. Предложеният от авторите новаторски, нетрадиционен и атрактивен подход при представяне на съдържанието улеснява детето в учебната му дейност, превръща ученето и четенето в забавно и желано занимание.",
                            HoursPerWeek = 5
                        },

                        new SubCourse()
                        {
                            Name= "Околен свят",
                            Description = "Природата винаги е внушителна, убедителна, прекрасна.Тя е храм, в който трябва винаги да влизаме с преклонение.",
                            HoursPerWeek = 4
                        }
                    }
                },

                new Course()
                {
                    Name = "Трети клас",
                    SubCourses = new HashSet<SubCourse>()
                    {
                        new SubCourse()
                        {
                            Name = "Математика за трети клас",
                            Description = "Несъмнено едно от предизвикателствата пред малките ученици е разбирането и решаването на текстови задачи.Ще се научат да съставят текстови задачи, да подреждат изречения, така че да се получи текстова задача и ще развият умения за решаването им",
                            HoursPerWeek = 6
                        },

                        new SubCourse()
                        {
                            Name="Граматика за трети клас",
                            Description = "Включва теория и много практически упражнения, изключително полезни за обогатяване на езиковата култура на първокласниците.",
                            HoursPerWeek = 7
                        },

                        new SubCourse()
                        {
                            Name= "Четене за трети клас",
                            Description = "Предназначено за овладяване техниките на четене от първокласниците. Предложеният от авторите новаторски, нетрадиционен и атрактивен подход при представяне на съдържанието улеснява детето в учебната му дейност, превръща ученето и четенето в забавно и желано занимание.",
                            HoursPerWeek = 5
                        },

                        new SubCourse()
                        {
                            Name= "Музика за трети клас",
                            Description = "Намерена е логическа връзка на творби от българския фолклор, на произведения от класически и съвременни автори. Изпълнението на песните с инструментални съпроводи доставя радост и желание за индивидуална изява, развива детската артистичност, прави певческата дейност изключително приятна и развлекателна.",
                            HoursPerWeek = 4
                        }
                    }
                },

               new Course()
                {
                    Name = "Четвърти клас",
                    SubCourses = new HashSet<SubCourse>()
                    {
                        new SubCourse()
                        {
                            Name = "Математика за четвърти клас",
                            Description = "Несъмнено едно от предизвикателствата пред малките ученици е разбирането и решаването на текстови задачи.Ще се научат да съставят текстови задачи, да подреждат изречения, така че да се получи текстова задача и ще развият умения за решаването им",
                            HoursPerWeek = 6
                        },

                        new SubCourse()
                        {
                            Name="Граматика за четвърти клас",
                            Description = "Включва теория и много практически упражнения, изключително полезни за обогатяване на езиковата култура на първокласниците.",
                            HoursPerWeek = 7
                        },

                        new SubCourse()
                        {
                            Name= "Четене за четвърти клас",
                            Description = "Предназначено за овладяване техниките на четене от първокласниците. Предложеният от авторите новаторски, нетрадиционен и атрактивен подход при представяне на съдържанието улеснява детето в учебната му дейност, превръща ученето и четенето в забавно и желано занимание.",
                            HoursPerWeek = 5
                        },

                        new SubCourse()
                        {
                            Name= "Околен свят за четвърти клас",
                            Description = "Природата винаги е внушителна, убедителна, прекрасна.Тя е храм, в който трябва винаги да влизаме с преклонение.",
                            HoursPerWeek = 4
                        }
                    }
                }

            });
        }
    }
}
