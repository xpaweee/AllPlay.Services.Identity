using Messier.Attributes;
using Messier.Interfaces;

namespace AllPlay.Services.Identity.Api;

[Message("identity", "test_queue")]
public class TestMessage : IMessage
{
    public Guid Id { get; set; }
}