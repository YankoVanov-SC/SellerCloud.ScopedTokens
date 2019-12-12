using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

using Common.Extensions;
using Common.Interfaces;

namespace Common.Builders
{
    public class WindowsTokenBuilder : ITokenBuilder
    {
        public string Build(IEnumerable<IHardwareIdProvider> providers)
        {
            try
            {
                var sb = new StringBuilder();

                var pieces = providers
                    .AsParallel()
                    .AsOrdered()
                    .Select(provider => new { Provider = provider, Identifier = provider.FetchHardwareId() })
                    .ToList();

                foreach (var piece in pieces)
                {
                    sb.Append(piece.Identifier);
                }

                return sb.ToString().HashWithSHA256();
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
