using System.Collections.Generic;

public class PieceAlphil : PieceOfChest
{
    public override List<PositionInTable> ListPosicionInTable(Ground ground, Ground[,] groundMap, Map map)
    {
        var rowNow = -1;
        var columnNow = -1;
        for (var row = 0; row < map.Heigth;row++)
        {
            for (var column = 0; column < map.Width;column++)
            {
                if(groundMap[row, column].gameObject.name.Equals(ground.gameObject.name))
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
        List<PositionInTable> listResult = new List<PositionInTable>();

        PositionInTable p;
        while(rowNow + 1 < map.Heigth && columnNow + 1 < map.Width)
        {
            rowNow += 1;
            columnNow += 1;
            p = new PositionInTable(rowNow, columnNow);
            listResult.Add(p);
        }

        return listResult;
    }
}
