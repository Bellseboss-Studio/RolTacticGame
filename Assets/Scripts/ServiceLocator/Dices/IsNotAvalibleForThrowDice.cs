using System;
using System.Runtime.Serialization;

[Serializable]
internal class IsNotAvalibleForThrowDice : Exception
{
    public IsNotAvalibleForThrowDice()
    {
    }

    public IsNotAvalibleForThrowDice(string message) : base(message)
    {
    }

    public IsNotAvalibleForThrowDice(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected IsNotAvalibleForThrowDice(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}