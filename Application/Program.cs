using System;
using CollageProj;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MAIN APP STARTING!");
            //Get subjects
            var SubjectList = Fetch.GetDataFromHttp().GetAwaiter().GetResult();
            College myCollege = new College(SubjectList);
            myCollege.ShowSubjectz();
        }






    }
}
