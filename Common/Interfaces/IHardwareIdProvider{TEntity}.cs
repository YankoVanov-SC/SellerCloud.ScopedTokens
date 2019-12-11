namespace Common.Interfaces
{
    public interface IHardwareIdProvider<TEntity>
        : IHardwareIdProvider
          where TEntity : IHardwareEntity
    {
        TEntity Entity { get; }
    }
}
