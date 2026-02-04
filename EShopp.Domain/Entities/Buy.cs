using EShopp.Domain.Entities;
public class Buy
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedDate { get; set; }
}