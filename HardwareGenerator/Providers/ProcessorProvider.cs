using System.Management;
using Common.Interfaces;

using HardwareGenerator.HardwareEntities;

namespace HardwareGenerator.Providers
{
    public class ProcessorProvider : BaseProvider<ProcessorEntity>, IHardwareIDProvider
    {
        public ProcessorProvider()
            :this(new ProcessorEntity())
        {

        }

        public ProcessorProvider(ProcessorEntity entity) : base(entity)
        {
        }
    }
}
