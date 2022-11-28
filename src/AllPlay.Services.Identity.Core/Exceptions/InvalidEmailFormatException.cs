namespace AllPlay.Services.Identity.Core.Exceptions;

internal sealed class InvalidEmailFormatException : DomainException
{
    public string Email { get; private set; }
    public InvalidEmailFormatException(string email) : base($"Invalid email format {email}")
    {
        Email = email;
    }
}