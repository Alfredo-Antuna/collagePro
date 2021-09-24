using System;
using System.Collections.Generic;


namespace CollageProj
{
    public class Teacher
    {
        public string Name;

        public List<Class> Classes;

        private College _collegeHiredAt;

        public Teacher(string teacherName, College collegeHiredAt)
        {
            Name = teacherName;
            _collegeHiredAt = collegeHiredAt;
            Classes = new List<Class>();
        }

        public void MakeClass(string subject, int rows, int columns)
        {
            Class newClass = new Class(subject, this, rows, columns, _collegeHiredAt.MakeNewID());
            Classes.Add(newClass);
            _collegeHiredAt.AddClassToList(newClass);
        }

        public Class GetClassWithID(int classID)
        {
            foreach (Class aClass in Classes)
            {
                if (aClass.GetID() == classID)
                {
                    return aClass;
                }
            }

            return null;
        }

        public void CloseClass(int classID)
        {
            this.GetClassWithID(classID).Close();
        }

        public void MakeTest(int classID, int maxScore)
        {
            this.GetClassWithID(classID).MakeTest(maxScore);
        }

        public void GiveStudentsTest(int classID)
        {
            this.GetClassWithID(classID).TakeLatestTest();
        }

        public List<float> GetMeanScores(int classID)
        {
            return this.GetClassWithID(classID).GetMeanScores();
        }

        public List<int> GetMedianScores(int classID)
        {
            return this.GetClassWithID(classID).GetMedianScores();
        }
    }
}