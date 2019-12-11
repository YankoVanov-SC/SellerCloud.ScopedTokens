using Common.Interfaces;

namespace HardwareGenerator.HardwareEntities
{
    public class HardDiskEntity : IHardwareEntity
    {
        public string ManagmentEntityId => "Win32_PhysicalMedia";

        public string EntityKey => "SerialNumber";
    }
}
