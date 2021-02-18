using System;
using System.Collections.Generic;

public class PieceHorse : PieceOfChest
{
    public override List<PositionInTable> ListPosicionInTable(Ground groundd)
    {
        ground = groundd;
        groundMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
        map = ServiceLocator.Instance.GetService<ICusor>().GetMap();

        List<PositionInTable> listResult = new List<PositionInTable>();

        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(1, 2));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(-1, -2));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(-1, 2));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(1, -2));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(2, 1));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(-2, -1));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(2, -1));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(-2, 1));
        }
        catch (PiecePositionFailException)
        { }

        return listResult;
    }
}