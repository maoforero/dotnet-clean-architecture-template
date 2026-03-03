using System.Data;

public class Invoice
{
    public int Id { get; private set; }
    public DateTime GeneratedAt { get; private set; }
    public Decimal Amount { get; private set; }
    public User User { get; private set; }
    public string Description { get; private set; } = string.Empty;


    public Invoice(Decimal amount, User user)
    {
        GeneratedAt = DateTime.Now;
        Amount = amount;
        User = user;
    }

    public void AggregateComments(string comments)
    {
        if(string.IsNullOrWhiteSpace(comments))
            Description = string.Empty;

        Description = comments;
    }
}