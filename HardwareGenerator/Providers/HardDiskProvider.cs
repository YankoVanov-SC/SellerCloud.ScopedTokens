using System.Management;

using Common.Interfaces;

using HardwareGenerator.HardwareEntities;

namespace HardwareGenerator.Providers
{
    public class HardDiskProvider : BaseProvider<HardDiskEntity>, IHardwareIDProvider
    {
        public HardDiskProvider()
            : this(new HardDiskEntity())
        {

        }
        public HardDiskProvider(HardDiskEntity entity) : base(entity)
        {
        }
    }
}
