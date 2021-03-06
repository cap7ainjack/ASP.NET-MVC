﻿using KidsAcademy.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KidsAcademy.Models.ViewModels.User;
using AutoMapper;
using KidsAcademy.Models.BindingModels;

namespace KidsAcademy.Services
{
    public class UsersService : Service
    {
        public IEnumerable<Course> GetAllCourses()
        {
            var courses = this.Context.Courses.ToArray();
            return courses;
        }

        public void AddStudent(AddStudentBM student, string userName)
        {
            Student studentToAdd = new Student();
            studentToAdd = Mapper.Map<AddStudentBM, Student>(student);

            //studentToAdd.Adress = student.Adress;
            //studentToAdd.Birthdate = student.Birthdate;
            //studentToAdd.Course = this.Context.Courses.Find(student.Course);
            //studentToAdd.FirstName = student.FirstName;
            //studentToAdd.LastName = student.LastName;


            studentToAdd.Parent = this.Context.Parents.FirstOrDefault(parent => parent.User.UserName == userName);


            this.Context.Students.Add(studentToAdd);
            this.Context.SaveChanges();
        }

        public ParentProfileVM GetProfileVM(string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(x => x.UserName == userName);
            ParentProfileVM vm = Mapper.Map<ApplicationUser, ParentProfileVM>(currentUser);
            Parent currentParrent = this.Context.Parents.FirstOrDefault(parent => parent.User.Id == currentUser.Id);
            vm.Kids = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentCourseVM>>(currentParrent.Kids);
            
            return vm;
        }

        public EditUserVM GetEditVM(string userName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            EditUserVM vm = Mapper.Map<ApplicationUser, EditUserVM>(user);
            return vm;
        }

        public void EditUser(EditUserBM bm, string userName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            user.FirstName = bm.FirstName;
            user.LastName = bm.LastName;
            user.Email = bm.Email;
            user.PhoneNumber = bm.PhoneNumber;
            this.Context.SaveChanges();
        }
    }
}
