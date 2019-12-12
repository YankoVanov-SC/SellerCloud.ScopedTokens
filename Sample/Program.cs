using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

using Common.Builders;
using Common.HardwareEntities;
using Common.Interfaces;
using Common.Providers;

using HardwareGenerator.Providers;

namespace Sample
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                DumpToken();
            }
        }

        static void DumpToken()
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

                var nameProvider = new MachineNameIdProvider();
                var baseBoardProvider = new HardwareIdProvider(new BaseBoardEntity());
                var processorProvider = new HardwareIdProvider(new ProcessorEntity());

                Console.WriteLine("Entities");
                Console.WriteLine(new string('-', 20));

                var scoped_token = wb.Build(new List<IHardwareIdProvider>() { nameProvider, baseBoardProvider, processorProvider });

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

            Console.CursorTop = 0;
        }
    }
}
