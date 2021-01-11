using System;
using System.Collections.Generic;

public class Map
{
    IReadFileFromDevice readFile;

    public Map(string mapName, IReadFileFromDevice readFile)
    {
        this.readFile = readFile;
        InitMap(mapName);
    }

    private void InitMap(string mapName)
    {
        MapDetail = readFile.ReadFile(mapName);
    }

    public int Heigth { get => MapDetail.Count; }
    public int Width { get => MapDetail[0].Length; }
    public List<string[]> MapDetail { get; private set; }
}