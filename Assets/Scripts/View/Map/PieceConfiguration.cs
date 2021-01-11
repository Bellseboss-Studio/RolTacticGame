using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/pieceOfChestConfig")]
public class PieceConfiguration : ScriptableObject
{
    [SerializeField] private PieceOfChest[] pieces;
    private Dictionary<string, PieceOfChest> idToPiece;

    private void Awake()
    {
        idToPiece = new Dictionary<string, PieceOfChest>(pieces.Length);
        foreach (var piece in pieces)
        {
            idToPiece.Add(piece.Id, piece);
        }
    }

    public PieceOfChest GetPiecePrefabById(string id)
    {
        if (!idToPiece.TryGetValue(id, out var piece))
        {
            throw new PieceOfChestNotFoundException($"Piece with id {id} does not exit");
        }
        return piece;
    }
}