namespace IHateDotnet.Contracts
{
    public record OrdersResponse(
        Guid id,
        string Desc,
        decimal Price,
        string AssignedTo
    );
    
}