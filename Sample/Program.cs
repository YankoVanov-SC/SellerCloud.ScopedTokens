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
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                WindowsTokenBuilder wb = new WindowsTokenBuilder();

                var nameProvider = new MachineNameIdProvider();
                var baseBoardProvider = new HardwareIdProvider(new BaseBoardEntity());
                var processorProvider = new HardwareIdProvider(new ProcessorEntity());

                Console.WriteLine("Entities");
                Console.WriteLine(new string('-', 20));

                Console.WriteLine($"{nameProvider}: {nameProvider.FetchHardwareId()}");
                Console.WriteLine($"{baseBoardProvider}: {baseBoardProvider.FetchHardwareId()}");
                Console.WriteLine($"{processorProvider}: {processorProvider.FetchHardwareId()}");

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
