using Common.Interfaces;

namespace HardwareGenerator.HardwareEntities
{
    public class ProcessorEntity : IHardwareEntity
    {
        public string ManagmentEntityId => "Win32_Processor";

        public string EntityKey => "processorID";
    }
}
