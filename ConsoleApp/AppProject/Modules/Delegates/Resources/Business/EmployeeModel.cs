using System;

namespace AppProject.Modules.Delegates.Resources.Business
{
    public class EmployeeModel
    {
        private readonly int _ID;
        private readonly string _FirstName;
        private readonly string _LastName;
        private readonly string _Email;
        private readonly DateTime _Birthdate;
        private readonly DepartmentModel _Department;
        private readonly Gender _Gender;


        public EmployeeModel(int ID, string FirstName, string LastName, string Email, DateTime Birthdate, Gender Gender, DepartmentModel Department = null)
        {
            _ID = ID;
            _FirstName = FirstName;
            _LastName = LastName;
            _Email = Email;
            _Birthdate = Birthdate;
            _Department = Department;
            _Gender = Gender;
        }

        public int ID
        {
            get
            {
                return _ID;
            }
        }

        public string FirstName
        {
            get
            {
                return _FirstName;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
        }

        public Gender Gender
        {
            get
            {
                return _Gender;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _Birthdate;
            }
        }

        public DepartmentModel Department
        {
            get
            {
                return _Department;
            }
        }

    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }
}
