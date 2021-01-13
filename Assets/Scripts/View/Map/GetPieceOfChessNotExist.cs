using System;
using System.Runtime.Serialization;

[Serializable]
internal class GetPieceOfChessNotExist : Exception
{
    public GetPieceOfChessNotExist()
    {
    }

    public GetPieceOfChessNotExist(string message) : base(message)
    {
    }

    public GetPieceOfChessNotExist(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected GetPieceOfChessNotExist(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}