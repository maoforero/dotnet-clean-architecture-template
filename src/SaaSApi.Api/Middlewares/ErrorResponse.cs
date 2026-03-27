public record ErrorResponse
{
    public int Status { get; init; }
    public string Description { get; init; }
    public DateTime TimeStamp { get; init; }
}