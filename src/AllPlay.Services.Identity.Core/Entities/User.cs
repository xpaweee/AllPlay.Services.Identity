using AllPlay.Services.Identity.Core.ValueObjects;

namespace AllPlay.Services.Identity.Core.Entities;

public class User
{
    public Guid Id { get; private set; }
    public Login Username { get; private set; }
    public string Password { get; private set; }
    public Email Email { get; private set; }
    public DateTime CreateDateTime { get; set; }

    //EF
    private User()
    {
    }

    public User(Guid id, Login username, string password, Email email, DateTime createDateTime)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        CreateDateTime = createDateTime;
    }
}