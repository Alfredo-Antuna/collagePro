using System;
using System.Collections.Generic;
using System.Linq;

namespace CollageProj
{
    public class College
    {
        private List<string> _subjectList;
        public List<Teacher> TeacherList;
        public List<Student> StudentList;
        public List<Class> ClassList;

        public int LastID = 0;

        public int MakeNewID()
        {
            LastID++;
            return LastID;
        }

        public College(List<string> SubjectList)
        {
            _subjectList = SubjectList;
            TeacherList = new List<Teacher>();
            ClassList = new List<Class>();
            StudentList = new List<Student>();

        }

        public List<string> GetSubList()
        {
            return _subjectList;
        }
        public void ShowSubjects()
        {
            foreach (var item in _subjectList)
            {
                Console.WriteLine(item);
            }
        }

        public void HireTeacher(string name)
        {
            Teacher newTeacher = new Teacher(name, this);
            TeacherList.Add(newTeacher);
        }

        public void AddClassToList(Class someClass)
        {
            ClassList.Add(someClass);
        }

        public Teacher GetTeacher(string teacherName)
        {
            foreach (Teacher teacher in TeacherList)
            {
                if (teacher.Name == teacherName)
                {
                    return teacher;
                }
            }

            return null;
        }

        public Student GetStudent(string studentName)
        {
            foreach (Student student in StudentList)
            {
                if (student.Name == studentName)
                {
                    return student;
                }
            }

            return null;
        }

        public Class GetClass(int classID)
        {
            foreach (Class aClass in ClassList)
            {
                if (aClass.GetID() == classID)
                {
                    return aClass;
                }
            }

            return null;
        }

        public void AdmitStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                StudentList.Add(student);
                student.JoinCollege(this);
            }
        }
    }
}