using UnityEngine;

public class LogicCosumerMap
{
    private readonly ICosumerMap cosumerMap;
    private readonly Map map;
    private readonly IReadFileFromDevice read;
    private readonly int space;

    public LogicCosumerMap(ICosumerMap cosumerMapp, string nameMap)
    {
        cosumerMap = cosumerMapp;
        read = new ReadMapFromString();
        map = new Map(nameMap, read);
        space = 1;
        cosumerMap.PrintMapInTheView(map);
    }

    public Map GetMap()
    {
        return map;
    }
}