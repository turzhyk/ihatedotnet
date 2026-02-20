using ProductStore.DataAccess.Enums;

namespace ProductStore.DataAccess.Entities;

public class BusinesscardFinishTypeEntity
{
    public Guid Id { get; set; }
    public BusinesscardPaperCoating Type { get; set; } 
    public decimal Price { get; set; }
}