using Common.Interfaces;

namespace HardwareGenerator.HardwareEntities
{
    public class BiosEntity : IHardwareEntity
    {
        public string ManagmentEntityId => "Win32_BIOS";

        public string EntityKey => "SerialNumber";
    }
}
