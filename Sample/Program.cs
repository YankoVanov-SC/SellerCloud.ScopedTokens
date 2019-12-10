using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using Common.Builders;
using Common.Interfaces;

using HardwareGenerator.HardwareEntities;
using HardwareGenerator.Providers;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            var titile = @"
   _____                           __   ______      __            
  / ___/_________  ____  ___  ____/ /  /_  __/___  / /_____  ____ 
  \__ \/ ___/ __ \/ __ \/ _ \/ __  /    / / / __ \/ //_/ _ \/ __ \
 ___/ / /__/ /_/ / /_/ /  __/ /_/ /    / / / /_/ / ,< /  __/ / / /
/____/\___/\____/ .___/\___/\__,_/    /_/  \____/_/|_|\___/_/ /_/ 
               /_/                                                
";
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(titile);
                Console.ResetColor();

                Stopwatch watch = new Stopwatch();
                watch.Start();

                WindowsTokenBuilder wb = new WindowsTokenBuilder();

                var hardwareProvider = new HardwareIDProvider(new HardDiskEntity());
                var processorProvider = new HardwareIDProvider(new ProcessorEntity());
                var biosProvider = new HardwareIDProvider(new BiosEntity());

                Console.WriteLine("Entities");
                Console.WriteLine(new string('-', 20));

                var scoped_token = wb.Build(new List<IHardwareIDProvider<IHardwareEntity>>() { hardwareProvider, processorProvider, biosProvider });

                Console.WriteLine(new string('-', 20));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Generated token: {scoped_token}");
                Console.ResetColor();
                Console.WriteLine();

                watch.Stop();
                Console.WriteLine($"Token time cost: {watch.Elapsed}");
            }
            catch (ManagementException mex)
            {
                Console.WriteLine(mex);
            }
        }
    }
}
