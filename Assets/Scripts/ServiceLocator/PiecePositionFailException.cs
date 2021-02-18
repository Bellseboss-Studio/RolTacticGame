using System;
using System.Runtime.Serialization;

[Serializable]
public  class PiecePositionFailException : Exception
{
    public PiecePositionFailException()
    {
    }

    public PiecePositionFailException(string message) : base(message)
    {
    }

    public PiecePositionFailException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected PiecePositionFailException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}