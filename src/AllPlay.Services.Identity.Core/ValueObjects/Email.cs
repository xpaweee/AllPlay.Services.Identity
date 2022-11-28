using System.Text.RegularExpressions;
using AllPlay.Services.Identity.Core.Exceptions;

namespace AllPlay.Services.Identity.Core.ValueObjects;

public record Email
{
    private const string EMAIL_REGEX = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
    public string EmailAddress { get; }

    public Email(string emailAddress)
    {
        if (emailAddress.Length < 3 || !Regex.IsMatch(emailAddress, EMAIL_REGEX))
        {
            throw new InvalidEmailFormatException(emailAddress);
        }
    }

    public static implicit operator string(Email emailAddress)
        => emailAddress;

    public static implicit operator Email(string emailAddress)
        => new(emailAddress);

}