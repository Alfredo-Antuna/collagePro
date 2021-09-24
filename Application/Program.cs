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

            Console.WriteLine();

            // Get subjects
            //bool IsRunning = true;

            // var SubjectList = Fetch.GetDataFromHttp().GetAwaiter().GetResult();
            // College myCollege = new College(SubjectList);

            // while (IsRunning)
            // {

            //     Console.WriteLine("Press 0 for administration, Press 1 for Teacher, Press 2 for Student, or Press 3 to quit.");
            //     var choice = Console.ReadLine();

            //     if (choice == "0")
            //     {
            //         bool isHireing = true;

            //         while (isHireing)
            //         {

            //             Console.WriteLine("Please enter the name of the teacher you would like to hire, or Press MM to return to main menu.");
            //             var teacherName = Console.WriteLine();

            //             if (teacherName != "MM")
            //             {
            //                 myCollege.HireTeacher(teacherName);
            //             }
            //             else
            //             {
            //                 isHireing = false;
            //             }

            //         }

            //     }

            //     if (choice == "1")
            //     {

            //         Console.WriteLine("Press 0 to create a class, Press 1 to make a Test, and Press 2 to Grade.");
            //         var teacherChoice = Console.ReadLine();

            //         if (teacherChoice == "0")
            //         {

            //         }
            //         else if (teacherChoice == "1")
            //         {

            //         }
            //         else if (teacherChoice == "2")
            //         {

            //         }
            //     }

            //     if (choice == "2")
            //     {

            //     }

            //     if (choice == "3")
            //     {
            //         IsRunning = false;
            //     }
            // }



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

            foreach (Teacher teacher in myCollege.TeacherList)
            {
                foreach (Class someClass in teacher.Classes)
                {
                    int classID = someClass.GetID();
                    teacher.MakeTest(classID, 100);
                    teacher.GiveStudentsTest(classID);
                    teacher.GradeLatestTest(classID);
                }
            }

            Console.WriteLine();

            foreach (Student student in myCollege.StudentList)
            {
                student.ShowAllGrades();
            }

            Console.WriteLine();
        }
    }
}
