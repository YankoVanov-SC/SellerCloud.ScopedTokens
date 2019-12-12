using System;

using Common.Interfaces;

namespace Common.Providers
{
    public class MachineNameIdProvider: IHardwareIdProvider
    {
        public string FetchHardwareId()
        {
            // Normalize the machine name
            return Environment.MachineName?.ToUpper();
        }

        public override string ToString()
        {
            return nameof(Environment.MachineName);
        }
    }
}
