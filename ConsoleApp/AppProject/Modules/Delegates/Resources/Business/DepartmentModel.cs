namespace AppProject.Modules.Delegates.Resources.Business
{
    public class DepartmentModel
    {
        private readonly int _ID;
        private readonly string _Name;
        private readonly Sector _Sector;

        public DepartmentModel(int ID, string Name, Sector Sector)
        {
            _ID = ID;
            _Name = Name;
            _Sector = Sector;
        }
        public int ID
        {
            get
            {
                return _ID;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
        }
        public Sector Sector
        {
            get
            {
                return _Sector;
            }
        }
    }

    public enum Sector
    {
        Public = 1,
        Private = 2,
        Bank = 3
    }
}
