public class TurnSystem : ITurnSystem
{
    bool turnOfWhite = false;
    public bool IsTheTurnForThisPiece(PieceOfChest pieceOfChest)
    {
        if (turnOfWhite)
        {
            return pieceOfChest.Id.Contains("w");
        }
        else
        {
            return pieceOfChest.Id.Contains("b");
        }
    }

    public void ThePlayerMove()
    {
        turnOfWhite = !turnOfWhite;
    }
}
