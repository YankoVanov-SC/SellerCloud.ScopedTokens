using Common.Interfaces;

namespace HardwareGenerator.HardwareEntities
{
    public class BiosEntity : IHardwareEntity
    {
        public string ManagmentEntityID => "Win32_BIOS";

        public string EntityKey => "SerialNumber";
    }
}
