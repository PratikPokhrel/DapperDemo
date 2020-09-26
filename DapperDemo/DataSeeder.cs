using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo
{
    public class DataSeeder
    {
        public static void Initialize(ApplicationContext context)
        {
            Guid classId1 = new Guid("1aa7e223-a1f4-432c-bfe6-159be848c0fa");
            Guid classId2 = new Guid("9cc7e223-a1f4-432c-bfe6-159be848c0fa");
            Guid classId3 = new Guid("6cd7e223-a1f4-432c-bfe6-159be848c0fa");
            Guid classId4 = new Guid("6da7e223-a1f4-432c-bfe6-159be848c0fa");

            if (!context.Class.Any())
            {
                List<Class> classes = new List<Class>
                {
                    new Class(classId1,"Class One","Class 1 Description"),
                    new Class(classId2,"Class Two","Class 2 Description"),
                    new Class(classId3,"Class Three","Class 3 Description"),
                    new Class(classId4,"Class Four","Class 4 Description"),
                };

                context.Class.AddRange(classes);
                context.SaveChanges();
            }

            Guid stdId1 = new Guid("6eb7e114-a1f4-432c-bfe6-159be848c0fa");
            Guid stdId2 = new Guid("8ff7e223-a1f4-432c-bfe6-159be848c0fa");
            Guid stdId3 = new Guid("9dd7e223-a1f4-432c-bfe6-159be848c0fa");
            Guid stdId4 = new Guid("7bb7e223-a1f4-432c-bfe6-159be848c0fa");

            if (!context.Student.Any())
            {
                List<Student> students = new List<Student>
                {
                    new Student(stdId1,"Pratik","Pokharel","pratik.pokhrel@gmail.com",classId1),
                    new Student(stdId2,"Jon","Doe","john.doe@gmail.com",classId2),
                    new Student(stdId3,"Jason","Smith","jason.smith@gmail.com",classId3),
                    new Student(stdId4,"Steve","Smith","steve.smith@gmail.com",classId4),

                };
                context.Student.AddRange(students);
                context.SaveChanges();
            }

            Guid course1 = new Guid("1ab7e223-a1f4-432c-bfe6-159be848c0fa");
            Guid course2 = new Guid("9bc7e223-a1f4-432c-bfe6-159be848c0fa");
            Guid course3 = new Guid("1ad7e223-a1f4-432c-bfe6-159be848c0fa");
            Guid course4 = new Guid("2ca7e223-a1f4-432c-bfe6-159be848c0fa");

            if (!context.Course.Any())
            {
                List<Course> courses = new List<Course>
                {
                    new Course(course1,"Engineering","Engineering Description"),
                    new Course(course2,"Accounting","Accounting Description"),
                    new Course(course3,"Biology","Biology Description"),
                    new Course(course4,"Geology","Geology Description"),
                };

                context.Course.AddRange(courses);
                context.SaveChanges();
            }


            if (!context.StudentCourse.Any())
            {
                List<StudentCourse> studentCourses = new List<StudentCourse>
                {
                    new StudentCourse(Guid.NewGuid(),stdId1,course1),
                    new StudentCourse(Guid.NewGuid(),stdId1,course2),
                    new StudentCourse(Guid.NewGuid(),stdId1,course3),
                    new StudentCourse(Guid.NewGuid(),stdId1,course1),
                    new StudentCourse(Guid.NewGuid(),stdId1,course2),
                    new StudentCourse(Guid.NewGuid(),stdId4,course3),
                    new StudentCourse(Guid.NewGuid(),stdId4,course4),
                };

                context.StudentCourse.AddRange(studentCourses);
                context.SaveChanges();
            }
        }
    }
}
