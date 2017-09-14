namespace Droplab.Data.Models
{
    public class OrderItem : BaseEntity
    {
        public Order Order { get; set; }
        public long OrderId { get; set; }
    }
}