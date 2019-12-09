using System.Management;
using Common.Interfaces;
using HardwareGenerator.HardwareEntities;

namespace HardwareGenerator.Providers
{
    public class BiosProvider : BaseProvider<BiosEntity>, IHardwareIDProvider
    {
        public BiosProvider()
            : this(new BiosEntity())
        {

        }
        public BiosProvider(BiosEntity entity) : base(entity)
        {
        }
    }
}
