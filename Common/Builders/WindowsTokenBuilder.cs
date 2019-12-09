using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Common.Interfaces;

namespace Common.Builders
{
    public class WindowsTokenBuilder : ITokenBuilder
    {
        public async Task<string> Build(IEnumerable<IHardwareIDProvider> providers)
        {
            byte[] bytes;
            byte[] hashedBytes;
            var sb = new StringBuilder();

            Task task = Task.Run(() =>
            {
                foreach (var provider in providers)
                {
                    sb.Append(provider.ReturnHardwareID());

                }
            });

            Task.WaitAll(task);

            bytes = Encoding.UTF8.GetBytes(sb.ToString());
            hashedBytes = SHA256.Create().ComputeHash(bytes);

            return await Task.FromResult(Convert.ToBase64String(hashedBytes));
        }
    }
}
