public abstract class BaseEntity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }



    public BaseEntity(DateTime created)
    {
        if (created == DateTime.MinValue) throw new ArgumentException("Create time cannot be null or empty");

        CreatedAt = created;
    }       

    public void MarkUpdated(DateTime updatedAt)
    {
        UpdatedAt = updatedAt;
    }

}