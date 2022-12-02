namespace AllPlay.Services.Identity.Application.Exceptions;

internal abstract class ApplicationException : Exception
{
    protected string Code { get;  set; }

    protected ApplicationException(string message) : base(message)
    {
        
    }
}