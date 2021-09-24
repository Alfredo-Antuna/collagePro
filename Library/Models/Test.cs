using System;
using System.Collections.Generic;
using System.Linq;

namespace CollageProj
{
    public class Test
    {
        private int _maxScore;
        public Dictionary<string, int> StudentScores;
        public Dictionary<string, float> StudentGrades;
        public Test(Student[] allStudents, int maxScore)
        {
            _maxScore = maxScore;

            foreach (Student student in allStudents)
            {
                StudentScores.Add(student.Name, 0);
                StudentGrades.Add(student.Name, 0);
            }
        }

        public void TakeTest(Student student, int score)
        {
            StudentScores[student.Name] = Math.Clamp(score, 0, _maxScore);
        }

        public void GradeAll()
        {
            foreach (KeyValuePair<string, int> pair in StudentScores)
            {
                StudentGrades[pair.Key] = (float)pair.Value / (float)_maxScore;
            }
        }

        public Tuple<int, float> GetScoreAndGrade(Student student)
        {
            return new Tuple<int, float>(StudentScores[student.Name], StudentGrades[student.Name]);
        }

        public float GetMeanScore()
        {
            float result = 0;

            foreach (KeyValuePair<string, int> pair in StudentScores)
            {
                result += (float)pair.Value;
            }

            result /= (float)StudentScores.Count;

            return result;
        }

        public int GetMedianScore()
        {
            List<int> allScores = StudentScores.Values.ToList<int>();
            allScores.Sort();

            return allScores[allScores.Count / 2];
        }

        public int GetMaxPossibleScore()
        {
            return _maxScore;
        }
    }
}