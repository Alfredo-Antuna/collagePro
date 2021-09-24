using FluentAssertions;
using System;
using System.Collections.Generic;
using CollageProj;
using Xunit;

namespace Aplication.Test
{
    public class CollegeTest
    {
        private College _testCollege;

        public CollegeTest()
        {
            List<string> testSubList = new List<string>
            {
                "Calculus",
                "Linear Algebra",
                "Probability",
                "Statistics",
                "Physics",
                "Biology",
                "Chemistry",
                "Electrical Engineering",
                "Computer Science",
                "Art",
                "Film",
                "Music",
                "Dance",
                "Literature",
                "Philosophy",
                "World History"
            };

            List<Student> testStudents = new List<Student>
            {
                new Student("Abigail"),
                new Student("Rodney"),
                new Student("Zach"),
                new Student("Bill"),
                new Student("William"),
                new Student("Jade")
            };

            _testCollege = new College(testSubList);
            _testCollege.AdmitStudents(testStudents);

            _testCollege.HireTeacher("George Smith");
            Teacher someTeacher = _testCollege.GetTeacher("George Smith");
            someTeacher.MakeClass("Literature", 5, 5);
        }
        [Fact]
        public void InitializedLists()
        {
            List<string> testSubList = new List<string>
            {
                "Calculus",
                "Linear Algebra",
                "Probability",
                "Statistics",
                "Physics",
                "Biology",
                "Chemistry",
                "Electrical Engineering",
                "Computer Science",
                "Art",
                "Film",
                "Music",
                "Dance",
                "Literature",
                "Philosophy",
                "World History"
            };

            int TestSubListIndex = 0;

            foreach (var item in _testCollege.GetSubList())
            {
                item.Should().Be(testSubList[TestSubListIndex]);
                TestSubListIndex++;
            }
        }


        [Fact]
        public void InitializeAClassWithGivenInfo()
        {
            Teacher someTeacher = new Teacher("Christopher Bacon", _testCollege);
            Class newClass = new Class("Calculus", someTeacher, 5, 5, _testCollege.MakeNewID());

            newClass.GetID().Should().Be(2);
            newClass.GetTeacher().Name.Should().Be("Christopher Bacon");
            newClass.GetSubject().Should().Be("Calculus");
            newClass.GetSeatingCapacity().Should().Be(25);
            newClass.IsOpen().Should().BeTrue();
        }

        [Fact]
        public void HireTeacherAndCreateClass()
        {
            _testCollege.HireTeacher("Samantha Jones");
            Teacher someTeacher = _testCollege.GetTeacher("Samantha Jones");
            someTeacher.Should().NotBeNull();
            someTeacher.MakeClass("Art", 5, 4);
            _testCollege.ClassList.Count.Should().Be(2);
            someTeacher.Classes.Count.Should().Be(1);
        }

        [Fact]
        public void AdmitStudents()
        {
            List<Student> newStudents = new List<Student>
            {
                new Student("Abigail"),
                new Student("Rodney"),
                new Student("Zach"),
                new Student("Bill"),
                new Student("William"),
                new Student("Jade")
            };

            //_testCollege.StudentList.Should().Equal(newStudents);

            int TestListIndex = 0;

            foreach (var student in _testCollege.StudentList)
            {
                student.Name.Should().Be(newStudents[TestListIndex].Name);
                TestListIndex++;
            }
        }

        [Fact]
        public void StudentsJoinClass()
        {
            Student student1 = _testCollege.GetStudent("Abigail");
            student1.JoinClass(1).Should().BeTrue();

            Student student2 = _testCollege.GetStudent("Rodney");
            student2.JoinClass(1).Should().BeTrue();
        }

        [Fact]
        public void TeacherClosesClassAndStudentTriesToJoin()
        {
            _testCollege.GetTeacher("George Smith").CloseClass(1);

            _testCollege.GetStudent("Zach").JoinClass(1).Should().BeFalse();
        }

        public void StudentTriesToJoinFullClass()
        {
            _testCollege.HireTeacher("John Gray");
            Teacher someTeacher = _testCollege.GetTeacher("John Gray");
            someTeacher.MakeClass("Statistics", 1, 1);

            _testCollege.GetStudent("Bill").JoinClass(2);
            _testCollege.GetStudent("William").JoinClass(2).Should().BeFalse();
        }

        public void StudentTriesToJoinOwnClass()
        {
            _testCollege.HireTeacher("John Gray");
            Teacher someTeacher = _testCollege.GetTeacher("John Gray");
            someTeacher.MakeClass("Statistics", 4, 4);

            _testCollege.GetStudent("Bill").JoinClass(2);
            _testCollege.GetStudent("Bill").JoinClass(2).Should().BeFalse();
        }
    }
}