using System;
using System.Collections.Generic;

public class PiecePeon : PieceOfChest
{
    private int firstMoved = 0;
    public override List<PositionInTable> ListPosicionInTable(Ground groundd)
    {
        ground = groundd;
        groundMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
        map = ServiceLocator.Instance.GetService<ICusor>().GetMap();
        List<PositionInTable> listResult = new List<PositionInTable>();

        if (ThisIsWhite())
        {
            if (firstMoved < 2)
            {
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(2, 0));
                    firstMoved++;
                }
                catch (PiecePositionFailException)
                { }
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(1, 0));
                }
                catch (PiecePositionFailException)
                { }
            }
            if (!HasPieceOnThisPosition(1, 1) && !HasPieceOnThisPosition(1, -1))
            {
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(1, 0));
                    return listResult;
                }
                catch (PiecePositionFailException)
                { }
            }
            if(HasPieceOnThisPosition(1, 1))
            {
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(1, 1));
                }
                catch (PiecePositionFailException)
                { }
            }

            if(HasPieceOnThisPosition(1, -1))
            {
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(1, -1));
                }
                catch (PiecePositionFailException)
                { }
            }


        }
        else
        {
            if (firstMoved < 2)
            {
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(-2, 0));
                    firstMoved++;
                }
                catch (PiecePositionFailException)
                { }
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(-1, 0));
                }
                catch (PiecePositionFailException)
                { }
            }
            
            if (!HasPieceOnThisPosition(-1, -1) && !HasPieceOnThisPosition(-1, 1))
            {
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(-1, 0));
                    return listResult;
                }
                catch (PiecePositionFailException)
                { }
            }
            if(HasPieceOnThisPosition(-1, -1))
            {
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(-1, -1));
                }
                catch (PiecePositionFailException)
                { }
            }
            if(HasPieceOnThisPosition(-1, 1))
            {
                try
                {
                    listResult.Add(PositionAvalibleOfOneIteration(-1, 1));
                }
                catch (PiecePositionFailException)
                { }
            }
        }
        return listResult;
    }

    private bool ThisIsWhite()
    {
        return Id.Contains("w");
    }
}
