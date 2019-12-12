using System.Collections.Generic;

using Common.Builders;
using Common.Extensions;
using Common.HardwareEntities;
using Common.Interfaces;
using Common.Providers;

using HardwareGenerator.Providers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Common
{
    public abstract class ScopedTokenTestBase
    {
        protected ITokenBuilder TokenBuilder { get; private set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            this.TokenBuilder = new WindowsTokenBuilder();
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
        }

        protected IList<IHardwareIdProvider> GetDefaultHardwareProviders()
        {
            return new List<IHardwareIdProvider>() { this.BaseBoardProvider, this.ProcessorProvider, this.MachineNameProvider };
        }

        protected IHardwareIdProvider BaseBoardProvider => new HardwareIdProvider(new BaseBoardEntity());
        protected IHardwareIdProvider ProcessorProvider => new HardwareIdProvider(new ProcessorEntity());
        protected IHardwareIdProvider MachineNameProvider => new MachineNameIdProvider();

        protected static string GetActual(string hddSerial)
        {
            return hddSerial.HashWithSHA256();
        }
    }
}
