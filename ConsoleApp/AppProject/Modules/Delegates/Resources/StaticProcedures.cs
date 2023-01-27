using AppProject.Core.Print;
using System;

namespace AppProject.Modules.Delegates.Resources
{
    public static class StaticProdecures
    {

        public static void NoParametersVoidReturn()
        {
            Console.WriteLine("Calling StaticSignature.NoParametersVoidReturn");
        }

        public static void NoParametersVoidReturnAgain()
        {
            Console.WriteLine("Calling StaticSignature.NoParametersVoidReturnAgain");
        }

        public static void WithParameterVoidReturn(string message)
        {
            Console.WriteLine("Calling StaticSignature.WithParameterVoidReturn(string message)" + " | " + message);
        }

        public static void WithParameterVoidReturn(IPrint printer)
        {
            printer.Print("Calling StaticSignature.WithParameterVoidReturn(IPrint printer)");
        }

        public static int NoParametersIntReturn()
        {
            return 1;
        }

        public static string NoParametersStringReturn()
        {
            return "This is a global return";
        }
    }
}
