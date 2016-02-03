using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistema_fichas.Business
{
    public class Entity<T> : BaseEntity, IEntity<T>
    {
        public virtual T ID { get; set; }
        
        [DefaultValue(true)]
        public virtual Boolean Status { get; set; }
    }
}
