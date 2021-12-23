using System.Linq;
using System;
using SampleWebAPI.Models;

namespace SampleWebAPI.Data
{
    public static class DbInitializer
    { 

        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Students.Any())
            {
                return;
            }

            var students = new Student[]
            {
                new Student{FirstName="Erick",LastName="Kurniawan",EnrollmentDate=DateTime.Parse("2021-12-12")},
                new Student{FirstName="Spongebob",LastName="Squarepants",EnrollmentDate=DateTime.Parse("2021-12-12")},
                new Student{FirstName="Yohan",LastName="Kang",EnrollmentDate=DateTime.Parse("2021-12-12")},
                new Student{FirstName="Gaon",LastName="Kim",EnrollmentDate=DateTime.Parse("2021-12-12")},
                new Student{FirstName="Yikyung",LastName="Song",EnrollmentDate=DateTime.Parse("2021-12-12")},
            };

            foreach (var s in students)
            {
                context.Students.Add(s);
            }

            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Title="Cloud Fundamentals",Credits=3},
                new Course{Title="Microservices Architecture",Credits=3},
                new Course{Title="Frontend Programming",Credits=3},
                new Course{Title="Backend RESTful API",Credits=3},
                new Course{Title="Entity FrameworkCore",Credits=3},
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1,Grade=Grade.A},
                new Enrollment{StudentID=1,CourseID=2,Grade=Grade.B},
                new Enrollment{StudentID=1,CourseID=3,Grade=Grade.C},
                new Enrollment{StudentID=2,CourseID=1,Grade=Grade.D},
                new Enrollment{StudentID=2,CourseID=2,Grade=Grade.E},
                new Enrollment{StudentID=2,CourseID=3,Grade=Grade.A},
                new Enrollment{StudentID=3,CourseID=1,Grade=Grade.B},
                new Enrollment{StudentID=3,CourseID=2,Grade=Grade.A},
                new Enrollment{StudentID=3,CourseID=3,Grade=Grade.C},
            };

            foreach (var e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            context.SaveChanges();
        }
    }
}
