using System;
using CollageProj;
using System.Collections.Generic;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Random _rng = new Random();

            Console.WriteLine("MAIN APP STARTING!");

            // Get subjects
            var SubjectList = Fetch.GetDataFromHttp().GetAwaiter().GetResult();
            College myCollege = new College(SubjectList);

            List<Student> students = new List<Student>();

            for (int i = 0; i < 100; i++)
            {
                //Console.WriteLine($"Making Student {i}");
                students.Add(new Student($"Student {i}"));
            }

            for (int i = 0; i < 10; i++)
            {
                //Console.WriteLine($"Making Teacher {i}");
                myCollege.HireTeacher($"Teacher {i}");
            }

            //Console.WriteLine($"Admitting Students");
            myCollege.AdmitStudents(students);

            foreach (Teacher teacher in myCollege.TeacherList)
            {
                for (int i = 0; i < 2; i++)
                {
                    //Console.WriteLine($"Making Class {myCollege.LastID + 1}");
                    teacher.MakeClass(SubjectList[(int)_rng.Next(SubjectList.Count)], 5, 5);
                }
            }

            foreach (Student student in myCollege.StudentList)
            {
                for (int i = 0; i < 4; i++)
                {
                    //Console.WriteLine($"{student.Name} tries to join a class");
                    bool joinedClass = student.JoinClass((int)_rng.Next(myCollege.ClassList.Count) + 1);

                    if (!joinedClass)
                    {
                        i--;
                    }
                }
            }

            foreach (Teacher teacher in myCollege.TeacherList)
            {
                foreach (Class someClass in teacher.Classes)
                {
                    //Console.WriteLine($"{teacher} closes a class");
                    teacher.CloseClass(someClass.GetID());
                }
            }

            foreach (Class someClass in myCollege.ClassList)
            {
                someClass.ShowMembers();
            }
        }
    }
}
