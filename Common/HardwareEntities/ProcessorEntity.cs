using Common.Interfaces;

namespace HardwareGenerator.HardwareEntities
{
    public class ProcessorEntity : IHardwareEntity
    {
        public string ManagmentEntityID => "Win32_Processor";

        public string EntityKey => "processorID";
    }
}
