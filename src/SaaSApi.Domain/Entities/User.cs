using System.Data;

public class User : BaseEntity{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public Guid? ActiveSubscriptionId { get; private set;}

    private User()
    {
        
    }

    public static User Create(string firstName, string lastName, string email)
    {
        if(string.IsNullOrWhiteSpace(firstName)) throw new ArgumentException("First name must have valid values.");
        if(string.IsNullOrWhiteSpace(lastName)) throw new ArgumentException("Last name must have valid values.");
        if(string.IsNullOrWhiteSpace(email) || !email.Contains("@")) throw new ArgumentException("Email must have valid values.");

        var user = new User();

        user.FirstName = firstName;
        user.LastName = lastName;
        user.Email = email;

        return user;
    }
}