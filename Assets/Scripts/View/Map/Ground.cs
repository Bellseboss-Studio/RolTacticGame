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

    public bool isEmpty() => piece == null;
}