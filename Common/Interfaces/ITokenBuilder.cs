using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface ITokenBuilder
    {
        string Build(IEnumerable<IHardwareIdProvider<IHardwareEntity>> providers);
    }
}
