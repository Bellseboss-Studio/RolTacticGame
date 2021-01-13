using UnityEngine;

public abstract class Ground : MonoBehaviour
{
    [SerializeField] private string id;
    private PieceOfChest piece;

    public string Id => id;

    public void AddPieceOfChest(PieceOfChest piece)
    {
        this.piece = piece;
    }

    public PieceOfChest GetPiece()
    {
        if (isEmpty())
        {
            throw new GetPieceOfChessNotExist("The piece in this ground not exist");
        }
        return piece;
    }

    public bool isEmpty() => piece == null;
}