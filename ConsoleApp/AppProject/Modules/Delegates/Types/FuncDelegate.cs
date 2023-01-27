using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Core.Watch;
using AppProject.Modules.Delegates.Resources;
using System;

namespace AppProject.Modules.Delegates.Types
{
    public class FuncDelegate : ModuleBase, IModule
    {
        // Define helpers
        private readonly IPrint _printer;

        public FuncDelegate() : base(new ConsolePrinter())
        {
            // Init helpers
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            NormalFuncDelegate();
            ExplicitFuncDelegate();
            LambdaFuncDelegate();

            // Points to Remember:
            // Func is built -in delegate type.
            // Func delegate type must return a value.
            // Func delegate type can have zero to 16 input parameters.
            // Func delegate does not allow ref and out parameters.
            // Func delegate type can be used with an anonymous method or lambda expression.
        }

        private void NormalFuncDelegate()
        {
            Func<int> FuncDelegateSignature;

            // Define delegate object pointer
            FuncDelegateSignature = StaticProdecures.NoParametersIntReturn;

            int result = FuncDelegateSignature.Invoke();

            _printer.Print(result.ToString());
        }

        private void ExplicitFuncDelegate()
        {
            Func<int> explicitDelegateObject = delegate () {
                return 1;
            };

            int result = explicitDelegateObject.Invoke();

            _printer.Print(result.ToString());
        }

        private void LambdaFuncDelegate()
        {
            // Example 1
            Func<int> getRandomNumber = () => new Random().Next(1, 100);

            _printer.Print(getRandomNumber().ToString());

            // Example 2
            Func<int, int, int> Sum = (x, y) => x + y;

            _printer.Print(Sum(2, 2).ToString());
        }
    }
}
