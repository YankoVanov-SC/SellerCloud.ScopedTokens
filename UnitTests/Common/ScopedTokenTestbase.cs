using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

using Common.Builders;
using Common.Interfaces;

using HardwareGenerator.HardwareEntities;
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

        protected IList<IHardwareIdProvider<IHardwareEntity>> GetDefaultHardwareProviders()
        {
            return new List<IHardwareIdProvider<IHardwareEntity>>() { this.HddProvider, this.ProcessorProvider, this.BiosProvider };
        }

        protected IHardwareIdProvider<IHardwareEntity> HddProvider => new HardwareIdProvider(new HardDiskEntity());
        protected IHardwareIdProvider<IHardwareEntity> ProcessorProvider => new HardwareIdProvider(new HardDiskEntity());
        protected IHardwareIdProvider<IHardwareEntity> BiosProvider => new HardwareIdProvider(new HardDiskEntity());

        protected static string GetActual(string hddSerial)
        {
            // TODO: Extension method string.Sha256()
            string actual;
            using (var sha256 = SHA256.Create())
            {
                actual = Convert.ToBase64String(sha256.ComputeHash((Encoding.UTF8.GetBytes(hddSerial))));
            };
            return actual;
        }
    }
}
