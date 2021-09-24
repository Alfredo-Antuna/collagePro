using System;
using System.Collections.Generic;

namespace CollageProj
{
    public class Student
    {
        public string Name;
        private College _collegeAttending;
        private List<Class> _myClasses;
        private Dictionary<int, List<float>> _myGrades;
        public Student(string name)
        {
            Name = name;
            _myClasses = new List<Class>();
            _myGrades = new Dictionary<int, List<float>>();
        }

        public void JoinCollege(College college)
        {
            _collegeAttending = college;
        }

        public bool JoinClass(int classID)
        {
            foreach (Class myClass in _myClasses)
            {
                if (classID == myClass.GetID())
                {
                    return false;
                }
            }

            Class classIWant = _collegeAttending.GetClass(classID);

            if (classIWant == null)
            {
                return false;
            }

            bool success = classIWant.TryToJoin(this);

            if (success)
            {
                _myClasses.Add(classIWant);
                _myGrades.Add(classIWant.GetID(), new List<float>());
                return true;
            }

            return false;
        }

        public void AddGradeForClass(int classID, float grade)
        {
            _myGrades[classID].Add(grade);
        }


        public void ShowAllGrades()
        {
            foreach (Class myClass in _myClasses)
            {
                float averageScore = 0;
                int totalTests = 0;

                foreach (float score in _myGrades[myClass.GetID()])
                {
                    averageScore += score;
                    totalTests++;
                }

                averageScore /= totalTests;
                averageScore *= 100;

                Console.WriteLine($"{myClass.GetSubject()}: {averageScore}%");
            }
        }
    }
}