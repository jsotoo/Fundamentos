using System;
using System.Reflection;

namespace AppProject.Core.Print
{
    public class ConsolePrinter : IPrint
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public void Print(object objectInstance)
        {
            Console.WriteLine(objectInstance);
        }
    }
}
