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

        public CollegeTest(){
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
            _testCollege = new College(testSubList);
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
            int TestSubListIndex = default;
            foreach (var item in _testCollege.GetSubList())
            {
                item.Should().Be(testSubList[TestSubListIndex]);
                TestSubListIndex++;
            }
           
        }


        [Fact]
        public void InitializeAClassWithGivenInfo()
        {

            
        }

    }
    
}