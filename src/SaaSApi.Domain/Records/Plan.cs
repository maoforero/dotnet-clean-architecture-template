using System.IO.Pipes;

public record Plan
{
    public string Type { get; init; }
    public decimal Amount { get; init; }
    public int MonthsOfValidity { get; init; }

    public Plan(string type, decimal amount, int months)
    {
        if(string.IsNullOrWhiteSpace(type)) throw new ArgumentException("The type of plan needs to be setted");
        if(amount < 0) throw new ArgumentException("The amount cannot be negative.");
        if(months < 0) throw new ArgumentException("The duration plan cannot be negative.");  

        Type = type;
        Amount = amount;
        MonthsOfValidity = months;
    }

}