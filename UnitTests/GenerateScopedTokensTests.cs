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
            var baseBoardSerial = this.BaseBoardProvider.FetchHardwareId();
            var processId = this.ProcessorProvider.FetchHardwareId();
            var machineName = this.MachineNameProvider.FetchHardwareId();

            string actual = GetActual($"{baseBoardSerial}{processId}{machineName}");

            var result = this.TokenBuilder.Build(GetDefaultHardwareProviders());
            Assert.IsNotNull(result);
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void GenerateScopedTokenWithBaseBoardProvidersShouldReturnValidToken()
        {

            var baseBoardProvider = this.BaseBoardProvider.FetchHardwareId();

            string actual = GetActual(baseBoardProvider);

            var result = this.TokenBuilder.Build(new List<IHardwareIdProvider>() { this.BaseBoardProvider });
            Assert.IsNotNull(result);
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void GenerateScopedTokenWithProcessorProvidersShouldReturnValidToken()
        {
            var processId = this.ProcessorProvider.FetchHardwareId();

            string actual = GetActual(processId);

            var result = this.TokenBuilder.Build(new List<IHardwareIdProvider>() { this.ProcessorProvider });
            Assert.IsNotNull(result);
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void GenerateScopedTokenWithBiosProvidersShouldReturnValidToken()
        {
            var machineName = this.MachineNameProvider.FetchHardwareId();

            string actual = GetActual(machineName);

            var result = this.TokenBuilder.Build(new List<IHardwareIdProvider>() { this.MachineNameProvider });
            Assert.IsNotNull(result);
            Assert.AreEqual(result, actual);
        }
    }
}
