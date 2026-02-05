namespace OrderStore.Core.Models;

public class OrderHistoryElement
{
    // public Guid Id { get; set; }
    public Guid OrderId { get;  }
    public string Status { get;  }
    public DateTime ChangedAt { get; }
    public string AuthorLogin { get;}

    public OrderHistoryElement(string status, string authorLogin, DateTime date)
    {
        Status = status;
        AuthorLogin = authorLogin;
        ChangedAt = date;
    }
}