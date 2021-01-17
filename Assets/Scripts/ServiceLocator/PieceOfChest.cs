using System.Collections.Generic;
using UnityEngine;

public abstract class PieceOfChest : MonoBehaviour
{
    [SerializeField] private string id;
    public string Id => id;
    public abstract List<PositionInTable> ListPosicionInTable(Ground ground, Ground[,] groundMap, Map map);
}