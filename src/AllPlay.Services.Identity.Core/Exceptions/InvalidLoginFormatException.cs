namespace AllPlay.Services.Identity.Core.Exceptions;

internal sealed class InvalidLoginFormatException : DomainException
{
    public string Username { get; private set; }
    
    public InvalidLoginFormatException(string username) : base($"Invalid username format {username}")
    {
        Username = username;
    }
}