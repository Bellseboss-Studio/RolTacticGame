using System;
using System.Collections.Generic;

public class PieceQueen : PieceOfChest
{
    public override List<PositionInTable> ListPosicionInTable(Ground groundd)
    {
        ground = groundd;
        groundMap = ServiceLocator.Instance.GetService<ICusor>().GetViewMap();
        map = ServiceLocator.Instance.GetService<ICusor>().GetMap();


        List<PositionInTable> listResult = new List<PositionInTable>();
        PositionInTable position;
        GetPositionsInMap(out var rowNow, out var columnNow);
        bool collision = false;
        while (rowNow + 1 < map.Heigth && columnNow + 1 < map.Width)
        {
            rowNow += 1;
            columnNow += 1;
            position = new PositionInTable(rowNow, columnNow);
            try
            {
                if (collision)
                {
                    break;
                }
                if (!groundMap[position.X, position.Y].isEmpty())
                {
                    collision = true;
                }
            }
            catch (Exception)
            {
                throw new PiecePositionFailException($"The piece, try moved in out of range in: {position.X} and {position.Y}");
            }
            listResult.Add(position);
        }

        GetPositionsInMap(out var rowNow2, out var columnNow2);
        collision = false;
        while (rowNow2 > 0 && columnNow2 > 0)
        {
            rowNow2 -= 1;
            columnNow2 -= 1;
            position = new PositionInTable(rowNow2, columnNow2);
            if (collision)
            {
                break;
            }
            if (!groundMap[position.X, position.Y].isEmpty())
            {
                collision = true;
            }
            listResult.Add(position);
        }

        GetPositionsInMap(out var rowNow3, out var columnNow3);
        collision = false;
        while (rowNow3 > 0 && columnNow3 + 1 < map.Width)
        {
            rowNow3 -= 1;
            columnNow3 += 1;
            position = new PositionInTable(rowNow3, columnNow3);
            if (collision)
            {
                break;
            }
            if (!groundMap[position.X, position.Y].isEmpty())
            {
                collision = true;
            }
            listResult.Add(position);
        }

        GetPositionsInMap(out var rowNow4, out var columnNow4);
        collision = false;
        while (rowNow4 + 1 < map.Heigth && columnNow4 > 0)
        {
            rowNow4 += 1;
            columnNow4 -= 1;
            position = new PositionInTable(rowNow4, columnNow4);
            if (collision)
            {
                break;
            }
            if (!groundMap[position.X, position.Y].isEmpty())
            {
                collision = true;
            }
            listResult.Add(position);
        }

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
