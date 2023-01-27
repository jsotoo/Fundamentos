using AppProject.Core.Module;
using AppProject.Core.Print;
using AppProject.Core.Watch;
using AppProject.Modules.Delegates.Resources;
using System;

namespace AppProject.Modules.Delegates.Types
{
    public class SimpleDelegate : ModuleBase, IModule
    {
        // Define delegate signatures
        private delegate void DelegateSignature1();
        private delegate void DelegateSignature2(string message);
        private delegate void DelegateSignature3(IPrint printer);

        private readonly IPrint _printer;
        private readonly IWatch _watcher;
        public SimpleDelegate() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
            _watcher = new Watcher();
        }
        public void Init()
        {
            Signature1();
            Signature2();
            Signature3();
        }

        private void Signature1()
        {
            // Define delegate object pointer
            DelegateSignature1 delegateObject1;

            // Create procedures instance
            InstanceProcedures procedures = new InstanceProcedures(_printer, _watcher);

            // Set method pointer
            delegateObject1 = procedures.Signature1;
            // Call delegate
            delegateObject1.Invoke();

            // Add additional pointer
            delegateObject1 += procedures.Signature1Again;
            // Call delegate
            delegateObject1.Invoke();

            // Add anonymous delegate
            delegateObject1 += new DelegateSignature1(delegate { Console.WriteLine("This is an anonymous delegate"); });
            // Call delegate
            delegateObject1.Invoke();

            // Add additional pointer
            delegateObject1 += StaticProdecures.NoParametersVoidReturn;
            // Call delegate
            delegateObject1.Invoke();

            // Remove Signature1 pointer
            delegateObject1 -= procedures.Signature1;
            // Call delegate
            delegateObject1.Invoke();

            // Remove StaticProdecures.Signature1 pointer
            delegateObject1 -= StaticProdecures.NoParametersVoidReturn;
            // Call delegate
            delegateObject1.Invoke();
        }

        private void Signature2()
        {
            // Define delegate object pointer
            DelegateSignature2 delegateObject2;

            // Create procedures instance
            InstanceProcedures procedures = new InstanceProcedures(_printer, _watcher);
            const string signature2Message = "Message signature 2";
            // Set method pointer
            delegateObject2 = procedures.Signature2;
            // Call delegate
            delegateObject2.Invoke(signature2Message);

            // Add additional pointer
            delegateObject2 += procedures.Signature2;
            // Call delegate
            delegateObject2.Invoke(signature2Message);

            // Add anonymous delegate
            delegateObject2 += new DelegateSignature2(delegate (string message) { Console.WriteLine(message); });
            // Call delegate
            delegateObject2.Invoke(signature2Message);

            // Add additional pointer
            delegateObject2 += StaticProdecures.WithParameterVoidReturn;
            // Call delegate
            delegateObject2.Invoke(signature2Message);
        }

        private void Signature3()
        {
            // Define delegate object pointer
            DelegateSignature3 delegateObject3;

            // Create procedures instance
            InstanceProcedures procedures = new InstanceProcedures(_printer, _watcher);

            // Set method pointer
            delegateObject3 = procedures.Signature3;
            // Call delegate
            delegateObject3.Invoke(_printer);

            // Add additional pointer
            delegateObject3 += StaticProdecures.WithParameterVoidReturn;
            // Call delegate
            delegateObject3.Invoke(_printer);
        }


    }
}
