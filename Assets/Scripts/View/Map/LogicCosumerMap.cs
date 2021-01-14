using UnityEngine;

public class LogicCosumerMap
{
    private ICosumerMap cosumerMap;
    private Map map;
    private IReadFileFromDevice read;
    private int space;

    public LogicCosumerMap(ICosumerMap cosumerMap, string nameMap)
    {
        this.cosumerMap = cosumerMap;
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