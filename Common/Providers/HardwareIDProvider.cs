using System;
using System.Linq;
using System.Management;

using Common.Interfaces;

namespace HardwareGenerator.Providers
{
    public class HardwareIDProvider : IHardwareIDProvider<IHardwareEntity>
    {
        protected string Query = "SELECT * FROM ";

        public IHardwareEntity Entity { get; set; }

        public HardwareIDProvider(IHardwareEntity entity)
        {
            this.Entity = entity;
        }

        public virtual string ReturnHardwareID()
        {
            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher($"{Query} {this.Entity.ManagmentEntityID}"))
                {
                    ManagementObject mo = searcher.Get().OfType<ManagementObject>()?.FirstOrDefault();
                    var r = mo?[this.Entity.EntityKey];
                    return mo?[this.Entity.EntityKey]?.ToString().Trim();
                }
            }
            catch (ManagementException mex)
            {
                throw mex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
