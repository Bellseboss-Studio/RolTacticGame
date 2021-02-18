using System.Collections.Generic;

public class PieceKing : PieceOfChest
{
    public override List<PositionInTable> ListPosicionInTable(Ground groundd)
    {
        ground = groundd;
        groundMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
        map = ServiceLocator.Instance.GetService<ICusor>().GetMap();

        List<PositionInTable> listResult = new List<PositionInTable>();

        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(1, 1));
        }
        catch (PiecePositionFailException)
        { }

        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(-1, -1));
        }
        catch (PiecePositionFailException)
        { }

        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(-1, 1));
        }
        catch (PiecePositionFailException)
        { }

        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(1, -1));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(0, -1));
        }
        catch (PiecePositionFailException)
        { }

        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(0, 1));
        }
        catch (PiecePositionFailException)
        { }

        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(-1, 0));
        }
        catch (PiecePositionFailException)
        { }

        try
        {
            listResult.Add(PositionAvalibleOfOneIteration(1, 0));
        }
        catch (PiecePositionFailException)
        { }

        return listResult;
    }
}
