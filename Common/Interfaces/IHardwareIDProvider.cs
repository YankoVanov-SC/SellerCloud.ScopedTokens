using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IHardwareIDProvider<TEntity>
        where TEntity : IHardwareEntity
    {
        TEntity Entity { get; set; }
        string ReturnHardwareID();
    }
}
