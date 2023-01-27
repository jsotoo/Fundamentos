using AppProject.Modules.Delegates.Resources.Business;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppProject.Modules.Delegates.Resources
{
    public static class StaticCollections
    {
        public static List<EmployeeModel> Employees
        {
            get
            {
                return new List<EmployeeModel> {
                    new EmployeeModel(1, "Luis Guillermo", "Andrade Manrique", "luis.andrade@gmail.com", new DateTime(1991,4,20), Gender.Male, Departments.Find(x => x.ID == 1)) {},
                    new EmployeeModel(2, "Juan ", "Cely Strauch", "juan.cely@gmail.com", new DateTime(1994,7,15), Gender.Male, Departments.Find(x => x.ID == 2)) {},
                    new EmployeeModel(4, "Andres", "Camacho", "andres.camacho@hotmail.com", new DateTime(1988,1,26), Gender.Male, Departments.Find(x => x.ID == 3)) {},
                    new EmployeeModel(5, "Luz", "Manrique", "luz.manrique@hotmail.com", new DateTime(1984,2,3), Gender.Female, Departments.Find(x => x.ID == 4)) {},
                    new EmployeeModel(6, "Ruben", "Lopez", "ruben.lopez@hotmail.com", new DateTime(1983,4,21), Gender.Male, Departments.Find(x => x.ID == 5)) {},
                    new EmployeeModel(7, "Julian", "Machado", "julian.machado@hotmail.com", new DateTime(1980,4,1), Gender.Male, Departments.Find(x => x.ID == 6)) {},
                    new EmployeeModel(8, "Daniela", "Ruiz", "daniela.ruiz@yahoo.com", new DateTime(1994,10,10), Gender.Female, Departments.Find(x => x.ID == 7)) {},
                    new EmployeeModel(9, "Luz", "Manrique", "luz.manrique@hotmail.com", new DateTime(1997,2,3), Gender.Female, Departments.Find(x => x.ID == 1)) {},
                    new EmployeeModel(10, "Paola", "Serrano", "paola.serrano@hotmail.com", new DateTime(1986,2,3), Gender.Female, Departments.Find(x => x.ID == 2)) {},
                    new EmployeeModel(10, "Jose", "Vergara", "jose.vergara@hotmail.com", new DateTime(1984,2,3), Gender.Female, Departments.Find(x => x.ID == 4)) {},
                    new EmployeeModel(10, "Patricia", "Paez", "patricia.paez@yahoo.com", new DateTime(1982,2,3), Gender.Female, Departments.Find(x => x.ID == 5)) {},
                    new EmployeeModel(10, "Blanca", "Parrado", "blanca.parrado@yahoo.es", new DateTime(1981,2,3), Gender.Female) {},
                    new EmployeeModel(10, "Bibiana", "Andrade", "bibiana.andrade@hotmail.com", new DateTime(1990,2,3), Gender.Female) {}
                };
            }
        }

        public static List<DepartmentModel> Departments
        {
            get
            {
                return new List<DepartmentModel>
                {
                    new DepartmentModel(1, "IT", Sector.Public),
                    new DepartmentModel(2, "Marketing", Sector.Public),
                    new DepartmentModel(3, "Production", Sector.Public),
                    new DepartmentModel(4, "Marketing", Sector.Private),
                    new DepartmentModel(5, "Production", Sector.Private),
                    new DepartmentModel(6, "Marketing", Sector.Bank),
                    new DepartmentModel(7, "Production", Sector.Bank),
                };
            }
        }
    }
}
