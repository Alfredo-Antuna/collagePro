namespace CollageProj
{
    





    public class Class{

        private int _classID;
        private string _name;
        private int _seatingCapacity;
        private string _subject;
        private Teacher _teacher;
        private Student[] _seats;




        public Class(int seatRows , int seatColumns ){
            _seats = new Student[seatRows*seatColumns];
            
        }
    }
}