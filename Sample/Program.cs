using System.Collections.Generic;
using Common.Builders;
using Common.Interfaces;
using HardwareGenerator.Providers;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsTokenBuilder wb = new WindowsTokenBuilder();

            HardDiskProvider hardwareProvider = new HardDiskProvider();
            ProcessorProvider processorProvider = new ProcessorProvider();
            BiosProvider biosProvider = new BiosProvider();

            var scoped_token = wb.Build(new List<IHardwareIDProvider>() { hardwareProvider, processorProvider, biosProvider }).Result;

            System.Console.WriteLine(scoped_token);
        }
    }
}
