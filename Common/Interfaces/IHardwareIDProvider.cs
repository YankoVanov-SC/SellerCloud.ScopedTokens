namespace Common.Interfaces
{
    public interface IHardwareIdProvider<TEntity>
        where TEntity : IHardwareEntity
    {
        TEntity Entity { get; }

        string FetchHardwareId();
    }
}
