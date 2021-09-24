using System;
using System.Collections.Generic;

namespace CollageProj
{

    public class Class
    {
        private Random _rng;
        private int _classID;
        private int _seatingCapacity;
        private int _rows;
        private int _columns;
        private string _subject;
        private Teacher _teacher;
        private Student[] _seats;
        private bool _isOpen;
        private List<Test> _tests;

        public Class(string subject, Teacher teacher, int seatRows, int seatColumns, int classID)
        {
            _rng = new Random();
            _isOpen = true;
            _classID = classID;
            _seatingCapacity = seatRows * seatColumns;
            _rows = seatRows;
            _columns = seatColumns;
            _seats = new Student[seatRows * seatColumns];
            _subject = subject;
            _teacher = teacher;
            _tests = new List<Test>();
        }

        public int GetID()
        {
            return _classID;
        }

        public Teacher GetTeacher()
        {
            return _teacher;
        }

        public string GetSubject()
        {
            return _subject;
        }

        public int GetSeatingCapacity()
        {
            return _seatingCapacity;
        }

        public bool IsOpen()
        {
            return _isOpen;
        }

        public bool TryToJoin(Student newStudent)
        {
            if (_isOpen && _seatingCapacity > 0)
            {
                int randomSeat = (int)_rng.Next((_rows * _columns));

                while (_seats[randomSeat] != null)
                {
                    //Console.WriteLine("This seat has been taken");
                    randomSeat = (randomSeat + 1) % (_rows * _columns);
                }

                _seats[randomSeat] = newStudent;
                _seatingCapacity--;

                return true;
            }

            return false;
        }

        public void Close()
        {
            _isOpen = false;
        }

        public void MakeTest(int maxScore)
        {
            _tests.Add(new Test(_seats, maxScore));
        }

        public void TakeLatestTest()
        {
            if (_tests.Count > 0)
            {
                int latestIndex = _tests.Count - 1;

                foreach (Student student in _seats)
                {
                    if (student != null)
                    {
                        _tests[latestIndex].TakeTest(student, (int)(_rng.Next(_tests[latestIndex].GetMaxPossibleScore())));
                    }
                }
            }
        }

        public void GradeLatestTest()
        {
            if (_tests.Count > 0)
            {
                int latestIndex = _tests.Count - 1;

                _tests[latestIndex].GradeAll();

                foreach (Student student in _seats)
                {
                    if (student != null)
                    {
                        student.AddGradeForClass(_classID, _tests[latestIndex].StudentGrades[student.Name]);
                    }
                }
            }
        }

        public List<float> GetMeanScores()
        {
            List<float> allMeanScores = new List<float>();

            foreach (Test test in _tests)
            {
                allMeanScores.Add(test.GetMeanScore());
            }

            return allMeanScores;
        }

        public List<int> GetMedianScores()
        {
            List<int> allMedianScores = new List<int>();

            foreach (Test test in _tests)
            {
                allMedianScores.Add(test.GetMedianScore());
            }

            return allMedianScores;
        }

        public void ShowMembers()
        {
            Console.WriteLine($"Class {_classID}: {_subject} taught by {_teacher.Name}");
            Console.WriteLine("STUDENT ROSTER");

            foreach (Student student in _seats)
            {
                if (student != null)
                {
                    Console.WriteLine($"{student.Name}");
                }
            }

            Console.WriteLine($"{_seatingCapacity} seats available");
        }
    }
}