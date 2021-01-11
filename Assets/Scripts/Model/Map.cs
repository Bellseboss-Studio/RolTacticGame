using System;

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
        var file = readFile.ReadFile(mapName);
        Heigth = file.Count;
        Width = file[0].Length;
    }

    public int Heigth { get; private set; }
    public int Width { get; private set; }
}