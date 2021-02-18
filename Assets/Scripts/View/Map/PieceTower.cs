using System.Collections.Generic;

public class PieceTower : PieceOfChest
{
    public override List<PositionInTable> ListPosicionInTable(Ground groundd)
    {
        ground = groundd;
        groundMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
        map = ServiceLocator.Instance.GetService<ICusor>().GetMap();
        List<PositionInTable> listResult = new List<PositionInTable>();

        try
        {
            listResult.AddRange(PositionAvalibleOfInIteration(1, 0));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.AddRange(PositionAvalibleOfInIteration(-1, 0));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.AddRange(PositionAvalibleOfInIteration(0, 1));
        }
        catch (PiecePositionFailException)
        { }
        try
        {
            listResult.AddRange(PositionAvalibleOfInIteration(0, -1));
        }
        catch (PiecePositionFailException)
        { }
        return listResult;
    }
}
