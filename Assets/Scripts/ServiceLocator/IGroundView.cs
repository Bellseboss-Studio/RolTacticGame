using UnityEngine;

public interface IGroundView
{
    void ChangedColor(Ground ground);
    void DestroyObject(GameObject go);
    void ChangedColorToMove(Ground ground);
    void ChangedLocalPositionToZero(PieceOfChest pieceOfChest);
}