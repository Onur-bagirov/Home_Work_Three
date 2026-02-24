namespace EShopp.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}