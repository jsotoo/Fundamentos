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
    public class EventSimpleExample : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public EventSimpleExample() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            Test test = new Test();
            test.TestEvent();
        }
    }

    public class MyTestEventHandler
    {
        public event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine("add operation");
            }
            remove
            {
                Console.WriteLine("remove operation");
            }
        }
    }

    public class Test
    {
        public void TestEvent()
        {
            MyTestEventHandler myTest = new MyTestEventHandler();
            myTest.MyEvent += myTest_MyEvent;
            myTest.MyEvent -= myTest_MyEvent;
        }
        public void myTest_MyEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Doing somthing...");
        }
    }
}
