using System;
using System.Collections.Generic;

public class PieceAlphil : PieceOfChest
{
    private Ground ground;
    private Ground[,] groundMap;
    private Map map;
    public override List<PositionInTable> ListPosicionInTable(Ground ground, Ground[,] groundMap, Map map)
    {
        this.ground = ground;
        this.groundMap = groundMap;
        this.map = map;

        GetPositionsInMap(out var rowNow, out var columnNow);
        List<PositionInTable> listResult = new List<PositionInTable>();
        PositionInTable p;
        while(rowNow + 1 < map.Heigth && columnNow + 1 < map.Width)
        {
            rowNow += 1;
            columnNow += 1;
            p = new PositionInTable(rowNow, columnNow);
            if (!groundMap[p.X, p.Y].isEmpty())
            {
                break;
            }
            listResult.Add(p);
        }

        GetPositionsInMap(out var rowNow2, out var columnNow2);
        while (rowNow2 > 0 && columnNow2 > 0)
        {
            rowNow2 -= 1;
            columnNow2 -= 1;
            p = new PositionInTable(rowNow2, columnNow2);
            if (!groundMap[p.X, p.Y].isEmpty())
            {
                break;
            }
            listResult.Add(p);
        }

        GetPositionsInMap(out var rowNow3, out var columnNow3);
        while (rowNow3 > 0 && columnNow3 + 1 < map.Width)
        {
            rowNow3 -= 1;
            columnNow3 += 1;
            p = new PositionInTable(rowNow3, columnNow3);
            if (!groundMap[p.X, p.Y].isEmpty())
            {
                break;
            }
            listResult.Add(p);
        }

        GetPositionsInMap(out var rowNow4, out var columnNow4);
        while (rowNow4 + 1 < map.Heigth && columnNow4 > 0)
        {
            rowNow4 += 1;
            columnNow4 -= 1;
            p = new PositionInTable(rowNow4, columnNow4);
            if (!groundMap[p.X, p.Y].isEmpty())
            {
                break;
            }
            listResult.Add(p);
        }

        return listResult;
    }

    private void GetPositionsInMap(out int rowNow, out int columnNow)
    {
        rowNow = -1;
        columnNow = -1;
        for (var row = 0; row < map.Heigth; row++)
        {
            for (var column = 0; column < map.Width; column++)
            {
                if (groundMap[row, column].gameObject.name.Equals(ground.gameObject.name))
                {
                    rowNow = row;
                    columnNow = column;
                    break;
                }
            }
            if (rowNow != -1 && columnNow != -1)
            {
                break;
            }
        }
    }
}
