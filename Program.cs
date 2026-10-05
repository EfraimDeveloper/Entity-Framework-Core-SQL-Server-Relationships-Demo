using EF_relationship_between_the_table.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace EF_relationship_between_the_table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Metho_Author();
            //Method_Author_Book();
            //Method_Author_Book_useRanger();
            //Add_Book_Author();
            //ShowAuthor();

            using (var contexto = new AppDbContext())
            {
               
                    // showData(contexto);

                LoadShowcourse(contexto);
            }
            Console.ReadLine();
        }

        private static void LoadShowcourse(AppDbContext contexto)
        {
           var students=contexto.Students.Include(e=> e.StudentCourses)
                                          .ThenInclude(e=> e.Course).ToList();

            foreach (var student in students)
            {
                Console.WriteLine($" Aluno{student.Name}");
                foreach (var course in student.StudentCourses.Select(e => e.Course))
                {
                    Console.WriteLine($" Curso {course.Name}");
                }
            }
        }

        private static void showData(AppDbContext contexto)
        {
            contexto.Database.EnsureDeleted();
            contexto.Database.EnsureCreated();

            var course_ = new[]
            {
             new Course {Name="C#",Description="B1"},
             new Course{Name="Microsoft Azure",Description="B2"},
             new Course{Name="React",Description="A2"}
          };

            var student_ = new[]
            {
                 new Student{Name="Efraim Luis Marcelino"},
                 new Student{Name="Alice Mundele"},
                 new Student{Name="Cristina Mundele Soko"}
             };

            contexto.AddRange(
                new StudentCourse { Course = course_[0], Student = student_[0] },
                new StudentCourse { Course = course_[1], Student = student_[1] },
                new StudentCourse { Course = course_[2], Student = student_[2] }
                );
            contexto.SaveChanges();
        }

        private static void ShowAuthor()
        {
            using (var contexto = new AppDbContext())
            {
                foreach (var author in contexto.Authors.AsNoTracking().Include(x=> x.Books)) {

                    Console.WriteLine($"{author.AuthorName}{author.Surname}");
                    foreach(var book in author.Books)
                    {
                        Console.WriteLine($"\t{book.Title }");
                    }
                }
            }
        }

        private static void Add_Book_Author()
        {
            using (var context =new AppDbContext())
            {
                var author = context.Authors.Find(1);
                var book = new Book { Title = "A casa Torta", year_of_release = 1949, Author = author };
                context.Books.Add(book);
                context.SaveChanges();
            }
        }

        private static void Method_Author_Book_useRanger()
        {
            using (var context = new AppDbContext())
            {
                var author = new Author()
                {
                    AuthorName = "Stephen ",
                    Surname = "King",
                };
                var books = new List<Book>
                {
                    new Book{ Title="Asp,do ADo e banco de dados na web",  year_of_release=2000,Author=author},
                    new Book{Title="Asp- aprender Rápido",year_of_release=2000,Author=author}
                };

                
                context.AddRange(books);
                context.SaveChanges();
            }
        }

        private static void Method_Author_Book()
        {
            using (var context = new AppDbContext())
            {
                var author = new Author()
                {
                    AuthorName = "Jose carlos",
                    Surname = "Macoratti",

                    Books = new List<Book>
                    {
                        new Book{ Title="Asp,do ADo e banco de dados na web",  year_of_release=2000},
                        new Book{Title="Asp- aprender Rápido",year_of_release=2000}
                    }

                };
                context.Authors.Add(author);
                context.SaveChanges();  
            }
        }

        private static void Metho_Author()
        {
            using (var contexto = new AppDbContext()) {

                var author = new Author 
                {
                    AuthorName = "Efraim", 
                    Surname = "Marcelino"
                };
                contexto.Authors.Add(author);
                contexto.SaveChanges();
            
            }
        }
    }
}
