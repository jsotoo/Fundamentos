using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppProject.Core.Reflection
{
    public interface IObjectReflection
    {
        Dictionary<string, string> GetPropertiesAndValues(dynamic parameter);
    }
}
