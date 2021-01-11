using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ReadMapFromDevice : IReadFileFromDevice
{
    public List<string[]> ReadFile(string path)
    {
        List<string[]> result = new List<string[]>();
        var line = Resources.Load<TextAsset>(path);
        byte[] byteArray = Encoding.ASCII.GetBytes(line.text);
        MemoryStream stream = new MemoryStream(byteArray);

        // convert stream to string
        StreamReader file = new StreamReader(stream);
        string lineRead = "";
        while ((lineRead = file.ReadLine()) != null)
        {
            result.Add(lineRead.Split(';'));
        }

        return result;
    }
}