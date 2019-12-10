using System;
using System.Collections.Generic;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Common.Interfaces;

namespace Common.Builders
{
    public class WindowsTokenBuilder : ITokenBuilder
    {
        public string Build(IEnumerable<IHardwareIDProvider<IHardwareEntity>> providers)
        {
            try
            {
                byte[] bytes;
                byte[] hashedBytes;
                var sb = new StringBuilder();

                foreach (var provider in providers)
                {
                    var identifier = provider.ReturnHardwareID();
                    Console.WriteLine($"{provider.Entity.ManagmentEntityID} / {provider.Entity.EntityKey}: {identifier}|");
                    sb.Append(identifier);
                }

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
