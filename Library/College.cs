using System;
using System.Collections.Generic;


namespace CollageProj
{




    public class College
    {

        private List<string> _subjectList;
        private List<Teacher> _teacherList;
        private List<Student> _studentList;
        private List<Class> _classList;



        public College(List<string> SubjectList)
        {
            _subjectList = SubjectList;
            _teacherList = new List<Teacher>();
            _classList = new List<Class>();
            _studentList = new List<Student>();
        
            
        }


        
        public List<string> GetSubList(){
            return _subjectList;
        }
        public void ShowSubjects(){
            foreach (var item in _subjectList)
            {
                Console.WriteLine(item);
            }
        }
    }

}