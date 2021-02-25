public class Dice : IServiceOfDies
{
    private int faces = 1;
    private IDices dicesFront;

    public int NumberResult { get; private set; }

    public Dice(int faces, IDices dicesFront)
    {
        NumberResult = 0;

        if (faces < 1)
        {
            faces = 1;
        }
        this.faces = faces;
        this.dicesFront = dicesFront;
    }

    public void ThrowDice()
    {
        NumberResult = dicesFront.RandomFront(1, faces);
    }

    public bool IsAvalibleGetNumber()
    {
        return NumberResult >= 1;
    }

    private string WherePieceIsAvalibleForMove()
    {
        if (IsAvalibleGetNumber())
        {
            var resultNumberOfDice = NumberResult;
            switch (resultNumberOfDice)
            {
                case 1:
                    return "a";
                case 2:
                    return "h";
                case 3:
                    return "k";
                case 4:
                    return "p";
                case 5:
                    return "q";
                case 6:
                    return "t";
            }
        }
        throw new IsNotAvalibleForThrowDice("Is not avalible for throw dice");
    }

    public string GetIdPiece()
    {
        dicesFront.DebugLocal(NumberResult);
        return WherePieceIsAvalibleForMove();
    }

    public void ResetDice()
    {
        NumberResult = 0;
    }
}