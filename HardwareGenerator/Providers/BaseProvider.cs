using System;
using System.Management;

using Common.Interfaces;

namespace HardwareGenerator.Providers
{
    public abstract class BaseProvider<TEntity>  : IHardwareIDProvider
        where TEntity : IHardwareEntity
    {
        protected string Query = "SELECT * FROM ";

        public TEntity Entity { get; set; }
         
        public BaseProvider(TEntity entity)
        {
            this.Entity = entity;
        }

        public virtual string ReturnHardwareID() 
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher($"{Query} {this.Entity.ManagmentEntityID}");
                ManagementObjectCollection entityCollection = searcher.Get();

                foreach (var obj in entityCollection)
                {
                    if (obj != null && !string.IsNullOrEmpty(obj[this.Entity.EntityKey]?.ToString()))
                    {
                        return obj[this.Entity.EntityKey]?.ToString();
                    }
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
