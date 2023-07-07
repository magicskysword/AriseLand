using System.Runtime.Serialization;

namespace AriseLand.Core.Exception;

public class LoadConfigureException : System.Exception
{
    public LoadConfigureException()
    {
    }

    protected LoadConfigureException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public LoadConfigureException(string? message) : base(message)
    {
    }

    public LoadConfigureException(string? message, System.Exception? innerException) : base(message, innerException)
    {
    }
}