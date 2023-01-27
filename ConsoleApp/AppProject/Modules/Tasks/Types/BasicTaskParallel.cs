using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Core.Watch;
using System.Threading;
using System.Threading.Tasks;

namespace AppProject.Modules
{

    public class BasicTaskParallel : ModuleBase, IModule
    {
        private IPrint _printer;
        private IWatch _watcher;
        public BasicTaskParallel() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
            _watcher = new Watcher();
        }

        public void Init()
        {
            TaskWithoutParallel();
            TaskWithParallel();
        }


        private void TaskWithoutParallel()
        {
            _printer.Print("Calling implementations of Task1 and Task2 without Parallel");

            _watcher.Start();
            Task1();
            Task2();
            _watcher.Stop();

            _printer.Print("Time taken executing tasks\n" + _watcher.GetTimeSpan());
        }

        private void TaskWithParallel()
        {
            _printer.Print("Calling implementations of Task1 and Task2 with Parallel");

            _watcher.Start();
            Parallel.Invoke(() => Task1(), () => Task2());
            _watcher.Stop();

            _printer.Print("Time taken executing tasks\n" + _watcher.GetTimeSpan());
        }

        private static void Task1()
        {
            Thread.Sleep(4000);
        }

        private void Task2()
        {
            Thread.Sleep(2000);
        }
    }
}
