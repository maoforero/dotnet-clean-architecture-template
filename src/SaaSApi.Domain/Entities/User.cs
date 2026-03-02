using System.Data;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public int Age { get; private set; }
    public Enum? Subscription { get; private set; }
    public DateTime CreateAt { get; private set; }
    public bool IsActive { get; private set; }
    public bool HasASusbcription { get; private set; }

    public User(string name, string email, int age)
    {
        Name = name;
        Email = email;
        Age = age;
    }

    public bool IsValid()
    {
        return Age > 18 ? true : false;
    }


}