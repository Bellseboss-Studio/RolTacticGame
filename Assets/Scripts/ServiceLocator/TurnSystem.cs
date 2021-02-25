public class TurnSystem : ITurnSystem
{
    bool turnOfWhite = false;
    IInstallerServiceLocator installerServiceLocator;

    public TurnSystem(IInstallerServiceLocator installerServiceLocator)
    {
        this.installerServiceLocator = installerServiceLocator;
        ThePlayerMove();
    }

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
        string whereIsTheTurn = turnOfWhite ? $"The turn is the White" : $"The turn is the Black";
        installerServiceLocator.WhriteTextInTurn(whereIsTheTurn);
    }
}
