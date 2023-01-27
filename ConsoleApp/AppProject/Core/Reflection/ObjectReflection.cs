using System;
using System.Collections.Generic;
using System.Reflection;

namespace AppProject.Core.Reflection
{
    public class ObjectReflection : IObjectReflection
    {
        public Dictionary<string, string> GetPropertiesAndValues(Object parameter)
        {
            Dictionary<string, string> propertiesAndValues = new Dictionary<string, string>();

            Type type = parameter.GetType();

            PropertyInfo[] propertiesInfo = type.GetProperties();

            for (int i = 0; i < propertiesInfo.Length; i++)
            {
                PropertyInfo propertyInfo = propertiesInfo[i];
                string propertyName = propertyInfo.Name;
                try
                {
                    string propertyValue = propertyInfo.GetValue(parameter).ToString();
                    propertiesAndValues.Add(propertyName, propertyValue);
                }
                catch (Exception)
                {
                    
                }
            }

            return propertiesAndValues;
        }
    }
}
