using System;
using System.Runtime.Serialization;

[Serializable]
internal class PieceOfChestNotFoundException : Exception
{
    public PieceOfChestNotFoundException()
    {
    }

    public PieceOfChestNotFoundException(string message) : base(message)
    {
    }

    public PieceOfChestNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected PieceOfChestNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}