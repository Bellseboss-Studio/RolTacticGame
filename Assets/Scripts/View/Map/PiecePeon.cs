using System;
using System.Collections.Generic;

public class PiecePeon : PieceOfChest
{
    public override List<PositionInTable> ListPosicionInTable(Ground ground)
    {
        List<PositionInTable> listResult = new List<PositionInTable>();

        if (ThisIsWhite())
        {
            try
            {
                listResult.Add(PositionAvalibleOfOneIteration(1, 1));
            }
            catch (PiecePositionFailException)
            { }
        }
        else
        {

        }

        return listResult;
    }

    private bool ThisIsWhite()
    {
        return Id.Contains("w");
    }
}
