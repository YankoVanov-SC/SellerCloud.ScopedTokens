using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Common.Interfaces;

namespace Common.Builders
{
    public class WindowsTokenBuilder : ITokenBuilder
    {
        public string Build(IEnumerable<IHardwareIdProvider<IHardwareEntity>> providers)
        {
            try
            {
                byte[] bytes;
                byte[] hashedBytes;
                var sb = new StringBuilder();

                // TODO: Use AsParallel()?
                foreach (var provider in providers)
                {
                    var identifier = provider.FetchHardwareId();
                    Console.WriteLine($"{provider.Entity.ManagmentEntityId} / {provider.Entity.EntityKey}: {identifier}");
                    sb.Append(identifier);
                }

                // TODO: Remove this and related duplicates, replace with string.Sha256() extension method
                bytes = Encoding.UTF8.GetBytes(sb.ToString());

                using (SHA256 sha256 = SHA256.Create())
                {
                    hashedBytes = sha256.ComputeHash(bytes);
                }

                return Convert.ToBase64String(hashedBytes);
            }
            catch (ManagementException mex)
            {
                throw mex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
