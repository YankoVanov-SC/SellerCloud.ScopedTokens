using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Common.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Common;

namespace UnitTests
{
    [TestClass]
    public class GenerateScopedTokensTests : ScopedTokenTestBase
    {
        [TestMethod]
        public void GenerateScopedTokenWithDefaultProvidersShouldReturnValidToken()
        {
            var hddSerial = this.HddProvider.FetchHardwareId();
            var processId = this.ProcessorProvider.FetchHardwareId();
            var biosSerial = this.BiosProvider.FetchHardwareId();

            string actual = GetActual($"{hddSerial}{processId}{biosSerial}");

            var result = this.TokenBuilder.Build(GetDefaultHardwareProviders());
            Assert.IsNotNull(result);
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void GenerateScopedTokenWithHardDiskProvidersShouldReturnValidToken()
        {

            var hddSerial = this.HddProvider.FetchHardwareId();

            string actual = GetActual(hddSerial);

            var result = this.TokenBuilder.Build(new List<IHardwareIdProvider<IHardwareEntity>>() { this.HddProvider });
            Assert.IsNotNull(result);
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void GenerateScopedTokenWithProcessorProvidersShouldReturnValidToken()
        {
            var processId = this.ProcessorProvider.FetchHardwareId();

            string actual = GetActual(processId);

            var result = this.TokenBuilder.Build(new List<IHardwareIdProvider<IHardwareEntity>>() { this.ProcessorProvider });
            Assert.IsNotNull(result);
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void GenerateScopedTokenWithBiosProvidersShouldReturnValidToken()
        {
            var biosSerial = this.BiosProvider.FetchHardwareId();

            string actual = GetActual(biosSerial);

            var result = this.TokenBuilder.Build(new List<IHardwareIdProvider<IHardwareEntity>>() { this.BiosProvider });
            Assert.IsNotNull(result);
            Assert.AreEqual(result, actual);
        }
    }
}
