using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO12.Models
{
    public class Student : ObservableObject
    {
        private int _id;
        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        private string _middleName;
        public string MiddleName
        {
            get => _middleName;
            set => SetProperty(ref _middleName, value);
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
        private DateTime _birthday;
        public DateTime Birthday
        {
            get => _birthday;
            set => SetProperty(ref _birthday, value);
        }
        private Passport _passport;
        public Passport Passport
        {
            get => _passport;
            set => SetProperty(ref _passport, value);
        }
        private int _groupId;
        public int GroupId
        {
            get => _groupId;
            set => SetProperty(ref _groupId, value);
        }
        private Group _group;
        public Group Group
        {
            get => _group;
            set => SetProperty(ref _group, value);
        }
    }
}
