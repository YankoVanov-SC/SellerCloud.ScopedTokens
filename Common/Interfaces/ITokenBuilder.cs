using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ITokenBuilder
    {
        Task<string> Build(IEnumerable<IHardwareIDProvider> providers);
    }
}
