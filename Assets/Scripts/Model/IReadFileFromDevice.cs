using System.Collections.Generic;

public interface IReadFileFromDevice
{
    List<string[]> ReadFile(string path);
}