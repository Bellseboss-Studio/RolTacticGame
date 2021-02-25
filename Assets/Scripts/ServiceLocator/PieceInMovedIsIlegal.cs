using System;
using System.Runtime.Serialization;

[Serializable]
internal class PieceInMovedIsIlegal : Exception
{
    public PieceInMovedIsIlegal()
    {
    }

    public PieceInMovedIsIlegal(string message) : base(message)
    {
    }

    public PieceInMovedIsIlegal(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected PieceInMovedIsIlegal(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}