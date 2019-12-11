using System;
using System.Linq;
using System.Management;

using Common.Interfaces;

namespace HardwareGenerator.Providers
{
    public class HardwareIdProvider : IHardwareIdProvider<IHardwareEntity>
    {
        public IHardwareEntity Entity { get; }

        public HardwareIdProvider(IHardwareEntity entity)
        {
            this.Entity = entity;
        }

        /// <exception cref="ManagementException" />
        public virtual string FetchHardwareId()
        {
            try
            {
                string query = $"SELECT {this.Entity.EntityKey} FROM {this.Entity.ManagmentEntityId}";

                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                {
                    ManagementObjectCollection results = searcher.Get();
                    ManagementObject result = results.OfType<ManagementObject>()?.FirstOrDefault();

                    object value = result?[this.Entity.EntityKey];
                    string normalized = $"{value}".Trim();

                    return normalized;
                }
            }
            catch (ManagementException mex)
            {
                throw mex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ToString()
        {
            return $"{this.Entity.ManagmentEntityId} / {this.Entity.EntityKey}";
        }
    }
}
