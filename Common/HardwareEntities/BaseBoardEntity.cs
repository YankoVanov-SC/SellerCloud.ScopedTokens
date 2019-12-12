using Common.Interfaces;

namespace Common.HardwareEntities
{
    public class BaseBoardEntity : IHardwareEntity
    {
        public string ManagmentEntityId => "Win32_BaseBoard";

        public string EntityKey => "SerialNumber";
    }
}
