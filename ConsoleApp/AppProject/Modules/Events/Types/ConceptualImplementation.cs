using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.Collections;

//Event Handlers in C# return void and take two parameters.
//The First parameter of Event - Source of Event means publishing object.
//The Second parameter of Event - Object derived from EventArgs.
//The publishers determines when an event is raised and the subscriber determines what action is taken in response.
//An Event can have so many subscribers.
//Events are basically used for the single user action like button click.
//If an Event has multiple subscribers then event handlers are invoked synchronously.

namespace AppProject.Modules
{
    public class ConceptualImplementation : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public ConceptualImplementation() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber(publisher);
            publisher.Add(new Product
            {
                ProductName = "Complan",
                Price = 20
            });
            publisher.Add(new Product
            {
                ProductName = "Horlics",
                Price = 120
            });
            publisher.Add(new Product
            {
                ProductName = "Boost",
                Price = 200
            });

            publisher.RemoveAt(2);
            publisher.RemoveAt(1);
            subscriber.UnSubscribeEvent();

            publisher.Add(new Product
            {
                ProductName = "Horlics",
                Price = 120
            });
            publisher.Add(new Product
            {
                ProductName = "Boost",
                Price = 200
            });
        }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public int Price { get; set; }
    }

    public delegate void EventHandler(object sender, EventArgs e);
    public class Publisher : ArrayList
    {
        public event EventHandler ProdcutAddedInfo;
        protected virtual void OnChanged(EventArgs e)
        {
            if (ProdcutAddedInfo != null) ProdcutAddedInfo(this, e);
        }
        public override int Add(Object product)
        {
            int added = base.Add(product);
            OnChanged(EventArgs.Empty);
            return added;
        }
        public override void Clear()
        {
            base.Clear();
            OnChanged(EventArgs.Empty);
        }
        public override object this[int index]
        {
            set
            {
                base[index] = value;
                OnChanged(EventArgs.Empty);
            }
        }
    }

    public class Subscriber
    {
        private Publisher publishers;
        public Subscriber(Publisher publisher)
        {
            this.publishers = publisher;
            publishers.ProdcutAddedInfo += publishers_ProdcutAddedInfo;
        }
        void publishers_ProdcutAddedInfo(object sender, EventArgs e)
        {
            if (sender == null)
            {
                Console.WriteLine("No New Product Added.");
                return;
            }
            Console.WriteLine("A New Prodct Added.");
        }
        public void UnSubscribeEvent()
        {
            publishers.ProdcutAddedInfo -= publishers_ProdcutAddedInfo;
        }
    }
}
