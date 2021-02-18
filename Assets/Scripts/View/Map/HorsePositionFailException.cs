using System;
using System.Runtime.Serialization;

[Serializable]
public class HorsePositionFailException : Exception
{
    public HorsePositionFailException()
    {
    }

    public HorsePositionFailException(string message) : base(message)
    {
    }

    public HorsePositionFailException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected HorsePositionFailException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}