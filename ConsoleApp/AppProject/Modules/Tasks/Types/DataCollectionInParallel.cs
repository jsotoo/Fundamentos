using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Core.Reflection;
using AppProject.Modules.Delegates.Resources;
using AppProject.Modules.Delegates.Resources.Business;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Modules.Tasks.Types
{
    public class DataCollectionInParallel : ModuleBase, IModule
    {
        private IPrint _printer;
        private readonly IObjectReflection _object;
        
        public DataCollectionInParallel() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
            _object = new ObjectReflection();
        }

        public void Init()
        {
            IterateCollection();
        }

        private void IterateCollection()
        {

            List<EmployeeModel> employees = StaticCollections.Employees;

            ConcurrentBag<EmployeeModel> filteredEmployees = new ConcurrentBag<EmployeeModel>();

            Parallel.ForEach(employees, (employee) =>
            {
                if(employee.Gender != Gender.Male)
                {
                    filteredEmployees.Add(employee);
                }
            });


            foreach (EmployeeModel employee in filteredEmployees)
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
