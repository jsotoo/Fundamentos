using AppProject.Core.Module;
using AppProject.Core.Print;
using System;

namespace AppProject.Modules
{
    public class Fundamentals : ModuleBase, IModule
    {
       private readonly IPrint _printer;

      
  
        public Fundamentals() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            DefaultValues();
            StringIntCast();
            Collections();
            ExtensionMethods();
        }

        public void DefaultValues()
        {
            _printer.Print("Default values examples");
            int i = default(int); // 0
            float f = default(float);// 0
            decimal d = default(decimal);// 0
            bool b = default(bool);// false
            char c = default(char);// '\0'
            DateTime dt = default(DateTime);
            string str = default(string);

            _printer.Print(i);
            _printer.Print(f);
            _printer.Print(d);
            _printer.Print(b);
            _printer.Print(c);
            _printer.Print(dt);
            _printer.Print(str);
        }

        public void ImplicitConvertions()
        {
            _printer.Print("Implicit convertions");
            int i = 345;
            float f = i;
            _printer.Print(f); //output: 345

            int i2 = 100;
            uint u2 = (uint)i2;
            _printer.Print(i2); // output: 100
        }

        public void StringIntCast()
        {
            //      Example: Parse()
            //Int16 result = Int16.Parse("100"); // returns 100
            //Int64 result = Int64.Parse("2147483649"); // returns 2147483649

            //      Example: Invalid Conversion
            //int.Parse(null);//thows FormatException
            //int.Parse("");//thows FormatException
            //int.Parse("100.00"); // throws FormatException
            //int.Parse("100a"); //throws formatexception
            //int.Parse(2147483649);//throws overflow exception use Int64.Parse()

            //        Example: Convert string to int using Convert class
            //Convert.ToInt16("100"); // returns short
            //        Convert.ToInt16(null);//returns 0

            //Convert.ToInt32("233300");// returns int
            //Convert.ToInt32("1234",16); // returns 4660 - Hexadecimal of 1234

            //Convert.ToInt64("1003232131321321");//returns long

            //// the following throw exceptions
            //Convert.ToInt16("");//throws FormatException
            //Convert.ToInt32("30,000"); //throws FormatException
            //Convert.ToInt16("(100)");//throws FormatException
            //Convert.ToInt16("100a"); //throws FormatException
            //Convert.ToInt16(2147483649);//throws OverflowException
        }

        public void Collections()
        {
            //// Ejercicio 1

            //// Create a list of strings.
            //var salmons = new List<string>();
            //salmons.Add("chinook");
            //salmons.Add("coho");
            //salmons.Add("pink");
            //salmons.Add("sockeye");

            //// Iterate through the list.
            //foreach (var salmon in salmons)
            //{
            //    Console.Write(salmon + " ");
            //}
            //// Output: chinook coho pink sockeye

            //// Ejercicio 2

            //// Create a list of strings by using a
            //// collection initializer.
            //var salmons = new List<string> { "chinook", "coho", "pink", "sockeye" };

            //// Iterate through the list.
            //foreach (var salmon in salmons)
            //{
            //    Console.Write(salmon + " ");
            //}
            //// Output: chinook coho pink sockeye
        }

        public void ExtensionMethods()
        {
            _printer.Print("Extension methods");

            // String extension method

            string message = "This is my message";

            int wordCount = message.MyOwnWordCount();

            _printer.Print(message + " have " + wordCount + " words");

            // Number extension method

            string numberToBeParsed = "288";

            int resultNumber = 0;

            numberToBeParsed.MyOwnTryParse(out resultNumber);

            _printer.Print(resultNumber);
        }
    }

    public static class MyExtensionMethods
    {
        public static int MyOwnWordCount(this string message)
        {
            return message.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static void MyOwnTryParse(this string stringNumber, out int outIntNumber)
        {
            outIntNumber = 0;
            try
            {
                outIntNumber = int.Parse(stringNumber);
            }
            catch (Exception)
            {

            }
        }
    }
}
