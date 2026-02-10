namespace IHateDotnet.Contracts;

public class AssignOrderRequest
{
    public Guid OrderId { get; set; }
    public string AuthorLogin { get; set; }
}