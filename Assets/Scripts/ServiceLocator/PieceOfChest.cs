using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PieceOfChest : MonoBehaviour
{
    [SerializeField] private string id;
    protected Ground ground;
    protected Ground[,] groundMap;
    protected Map map;

    public string Id => id;
    public abstract List<PositionInTable> ListPosicionInTable(Ground ground);

    protected List<PositionInTable> PositionAvalibleOfInIteration(int row, int column)
    {
        List<PositionInTable> listResult = new List<PositionInTable>();

        GetPositionsInMap(out var rowNow4, out var columnNow4);
        bool collision = false;
        while (rowNow4 + row < map.Heigth && rowNow4 + row >= 0 && columnNow4 + column >= 0 && columnNow4 + column < map.Heigth)
        {
            rowNow4 += row;
            columnNow4 += column;
            var position = new PositionInTable(rowNow4, columnNow4);
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
                Debug.Log($"Exception  in: {position.X} and {position.Y} : row {row}, column {column}");
                throw new PiecePositionFailException($"The piece, try moved in out of range in: {position.X} and {position.Y} : {row}, {column}"); 
            }
            Debug.Log($"in: {position.X} and {position.Y} : {row}, {column}");
            listResult.Add(position);
        }
        return listResult;
    }
    protected PositionInTable PositionAvalibleOfOneIteration(int row, int column)
    {
        GetPositionsInMap(out var rowNow, out var columnNow);
        rowNow += row;
        columnNow += column;
        var position = new PositionInTable(rowNow, columnNow);
        try
        {
            if (groundMap[position.X, position.Y].isEmpty())
            {

            }
            return position;
        }
        catch (Exception)
        {
            throw new PiecePositionFailException($"The piece, try moved in out of range in: {position.X} and {position.Y} : {row}, {column}");
        }
        throw new PiecePositionFailException($"The piece, in this moved is imposible in: {position.X} and {position.Y} : {row}, {column}");
    }

    protected bool HasPieceOnThisPosition(int row, int column)
    {
        GetPositionsInMap(out var rowNow, out var columnNow);
        rowNow += row;
        columnNow += column;
        var position = new PositionInTable(rowNow, columnNow);
        try
        {
            if (!groundMap[position.X, position.Y].isEmpty())
            {
                return true;
            }
        }
        catch (Exception)
        {
            throw new PiecePositionFailException($"The piece, try moved in out of range in: {position.X} and {position.Y} : {row}, {column}");
        }
        return false;
    }
    protected void GetPositionsInMap(out int rowNow, out int columnNow)
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

    public virtual void Restart()
    {

    }

    internal bool ThisPieceIsWhite()
    {
        return id.Contains("w");
    }
}