using System;
using System.Collections.Generic;

namespace Droplab.Data.Models
{
    public class Order : BaseEntity
    {
        public DateTime CreatedDate { get; set; }

        public State State { get; set; }
        public long StateId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        
    }
}