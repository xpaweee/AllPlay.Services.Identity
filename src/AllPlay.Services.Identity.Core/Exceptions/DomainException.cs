namespace AllPlay.Services.Identity.Core.Exceptions;

internal abstract class DomainException : Exception
{
    public virtual string Code { get;}

    protected DomainException(string message) : base(message)
    {
        
    }
}