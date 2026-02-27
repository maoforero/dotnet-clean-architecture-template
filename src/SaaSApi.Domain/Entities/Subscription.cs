namespace SaaSApi.Domain;

public class Subscription
{
    public Guid Id { get; private set; }
    public string UserEmail { get; private set; }
    public string PlanName { get; private set; }
    public DateTime EndDate { get; private set; }
    public bool IsActivate { get; private set; }

    public Subscription(
        Guid id,
        string email,
        string planName,
        int durationMonths
    )
    {
        if(string.IsNullOrEmpty(email) || !email.Contains("@"))
            throw new ArgumentException("This email is invalid.");

        Id = id;
        UserEmail = email;
        PlanName = planName;
        EndDate = DateTime.UtcNow.AddMonths(durationMonths);
        IsActivate = true;
    }

    public void Cancel() => IsActivate = false;
}
