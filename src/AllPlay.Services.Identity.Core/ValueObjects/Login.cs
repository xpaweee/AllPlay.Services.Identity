using AllPlay.Services.Identity.Core.Exceptions;

namespace AllPlay.Services.Identity.Core.ValueObjects;

public record Login
{
    public string Username { get; }

    public Login(string username)
    {
        if (username.Length < 3)
        {
            throw new InvalidLoginFormatException(username);
        }
        
        Username = username;
    }

    public static implicit operator string(Login login)
        => login.Username;

    public static implicit operator Login(string username)
        => new(username);
}