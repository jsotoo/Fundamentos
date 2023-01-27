using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.Collections.Generic;
using System.Linq;

//Event Handlers in C# return void and take two parameters.
//The First parameter of Event - Source of Event means publishing object.
//The Second parameter of Event - Object derived from EventArgs.
//The publishers determines when an event is raised and the subscriber determines what action is taken in response.
//An Event can have so many subscribers.
//Events are basically used for the single user action like button click.
//If an Event has multiple subscribers then event handlers are invoked synchronously.

namespace AppProject.Modules
{
    public class PrintExample : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public PrintExample() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            Number myNumber = new Number(100000);
            myNumber.PrintMoney();
            myNumber.PrintNumber();
        }
    }

    // Event
    public class PrintHelper
    {
        // declare delegate 
        public delegate void BeforePrint();

        //declare event of type delegate
        public event BeforePrint beforePrintEvent;

        public PrintHelper()
        {

        }

        public void PrintNumber(int num)
        {
            //call delegate method before going to print
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public void PrintDecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Decimal: {0:G}", dec);
        }

        public void PrintMoney(int money)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Money: {0:C}", money);
        }

        public void PrintTemperature(int num)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }
        public void PrintHexadecimal(int dec)
        {
            if (beforePrintEvent != null)
                beforePrintEvent();

            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }

    // Event subscriber
    class Number
    {
        private PrintHelper _printHelper;

        public Number(int val)
        {
            _value = val;

            _printHelper = new PrintHelper();
            //subscribe to beforePrintEvent event
            _printHelper.beforePrintEvent += printHelper_beforePrintEvent;
        }
        //beforePrintevent handler
        void printHelper_beforePrintEvent()
        {
            Console.WriteLine("BeforPrintEventHandler: PrintHelper is going to print a value");
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void PrintMoney()
        {
            _printHelper.PrintMoney(_value);
        }

        public void PrintNumber()
        {
            _printHelper.PrintNumber(_value);
        }
    }
}
