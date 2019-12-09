using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

using Common.Interfaces;

namespace Common.Builders
{
    public class WindowsTokenBuilder : ITokenBuilder
    {
        public async Task<string> Build(IEnumerable<IHardwareIDProvider> providers)
        {
            using (var ps = PowerShell.Create())
            {
                var results = ps.AddScript("Get-WmiObject Win32_BaseBoard").Invoke();
                foreach (var result in results)
                {
                    System.Console.WriteLine(result.ToString());
                }
            }

            return await Task.FromResult("");
        }
    }
}
