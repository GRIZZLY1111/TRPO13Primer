using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO12.Models
{
    public class Passport : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private int _series;
        public int Series
        {
            get => _series;
            set => SetProperty(ref _series, value);
        }
        private int _number;
        public int Number
        {
            get => _number;
            set => SetProperty(ref _number, value);
        }
        private int _studentId;
        public int StudentId
        {
            get => _studentId;
            set => SetProperty(ref _studentId, value);
        }
        private Student _student;
        public Student Student
        {
            get => _student;
            set => SetProperty(ref _student, value);
        }
    }
}
