public record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; init; }

    public Money (decimal amount, string currency)
    {
        
        if(amount <= 0 ) throw new ArgumentException("Amount must have positive values.");
        if(string.IsNullOrWhiteSpace(currency) || currency.Length != 3) throw new ArgumentException("Currency doesnt have valid values.");

        Amount = amount;
        Currency = currency;
    }
}