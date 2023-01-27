using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Core.Reflection;
using AppProject.Modules.Delegates.Resources;
using AppProject.Modules.Delegates.Resources.Business;
using System;
using System.Collections.Generic;

namespace AppProject.Modules.Delegates.Types
{
    public class PredicateDelegate : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        private readonly IObjectReflection _object;
        public PredicateDelegate() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
            _object = new ObjectReflection();
        }

        public void Init()
        {
            SearchSingleResult();
            SearchMultipleResult();
            MultipleSearchMultipleResult();
        }

        private void SearchSingleResult()
        {
            Predicate<EmployeeModel> nameSearchPredicate = x => x.FirstName == "Luis Guillermo";

            EmployeeModel luisEmployee = StaticCollections.Employees.Find(nameSearchPredicate);

            Dictionary<string, string> objectPropertiesAndValues = _object.GetPropertiesAndValues(luisEmployee);

            _printer.Print("Employee found");

            foreach (KeyValuePair<string, string> property in objectPropertiesAndValues)
            {
                _printer.Print(property.Key + ": "+ property.Value);
            }
        }

        private void SearchMultipleResult()
        {
            Predicate<EmployeeModel> genderSearchPredicate = x => x.Gender == Gender.Male;

            List<EmployeeModel> employees = StaticCollections.Employees.FindAll(genderSearchPredicate);

            _printer.Print("Employees found");

            foreach (EmployeeModel employee in employees)
            {
                Dictionary<string, string> objectPropertiesAndValues = _object.GetPropertiesAndValues(employee);

                foreach (KeyValuePair<string, string> property in objectPropertiesAndValues)
                {
                    _printer.Print(property.Key + ": " + property.Value);
                }
            }
        }

        private void MultipleSearchMultipleResult()
        {
            Predicate<EmployeeModel> genderSearchPredicate = x => x.Gender == Gender.Male || x.LastName == "Paez";

            List<EmployeeModel> employees = StaticCollections.Employees.FindAll(genderSearchPredicate);

            _printer.Print("Employees found");

            foreach (EmployeeModel employee in employees)
            {
                Dictionary<string, string> objectPropertiesAndValues = _object.GetPropertiesAndValues(employee);

                foreach (KeyValuePair<string, string> property in objectPropertiesAndValues)
                {
                    _printer.Print(property.Key + ": " + property.Value);
                }
            }
        }
    }
}
