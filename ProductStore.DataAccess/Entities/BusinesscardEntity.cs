namespace ProductStore.DataAccess.Entities;

public class BusinesscardEntity
{
    public Guid Id { get; set; }
    public string Density { get; set; }
    public string Finish { get; set; }
    public decimal Price { get; set; }
}