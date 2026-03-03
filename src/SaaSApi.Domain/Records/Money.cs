public record Money
{
    public decimal Amount {get; init;}
    public string Currency {get; init;}

    public Money(decimal amount, string currency)
    {

        if (amount < 0) throw new ArgumentException("The amount cannot be negative.");    
        if (string.IsNullOrWhiteSpace(currency)) throw new ArgumentException("The type of money is required.");

        Amount = amount;
        Currency = currency;
    }
}