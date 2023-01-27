using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Modules.Delegates.Resources;
using System;

namespace AppProject.Modules.Delegates.Types
{
    public class ActionDelegate : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        public ActionDelegate() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
        }

        public void Init()
        {
            NormalActionDelegate();
            ExplicitActionDelegate();
            LambdaActionDelegate();
        }

        private void NormalActionDelegate()
        {
            Action<string> normalActionDelegateObject = new Action<string>(StaticProdecures.WithParameterVoidReturn);
            normalActionDelegateObject("Normal Action Delegate message");
        }

        private void ExplicitActionDelegate()
        {
            Action<string> explicitActionDelegateObject = delegate (string message)
            {
                Console.WriteLine(message);
            };

            explicitActionDelegateObject.Invoke("Explicit Action Delegate message");
        }

        private void LambdaActionDelegate()
        {
            // Example 1
            Action<string> lambdaActionDelegateObject = (string message) => Console.WriteLine(message);

            lambdaActionDelegateObject("Lambda Action Delegate message");

        }

    }
}
