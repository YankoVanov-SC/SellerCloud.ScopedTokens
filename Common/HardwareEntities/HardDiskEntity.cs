using Common.Interfaces;

namespace HardwareGenerator.HardwareEntities
{
    public class HardDiskEntity : IHardwareEntity
    {
        public string ManagmentEntityID => "Win32_PhysicalMedia";

        public string EntityKey => "SerialNumber";
    }
}
