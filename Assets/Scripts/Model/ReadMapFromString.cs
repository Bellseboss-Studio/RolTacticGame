using System.Collections.Generic;
using System.IO;
using System.Text;

public class ReadMapFromString : IReadFileFromDevice
{
    public List<string[]> ReadFile(string path)
    {
        List<string[]> result = new List<string[]>();
        byte[] byteArray = Encoding.ASCII.GetBytes(chessMap);
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

    private string chessMap =   "tw-n;hw-b;aw-n;qw-b;kw-n;aw-b;hw-n;tw-b\n" +
                                "pw-b;pw-n;pw-b;pw-n;pw-b;pw-n;pw-b;pw-n\n" +
                                "n;b;n;b;n;b;n;b\n" +
                                "b;n;b;n;b;n;b;n\n" +
                                "n;b;n;b;ab-n;b;n;b\n" +
                                "b;n;b;n;b;n;b;n\n" +
                                "pb-n;pb-b;pb-n;pb-b;pb-n;pb-b;pb-n;pb-b\n" +
                                "tb-b;hb-n;ab-b;qb-n;kb-b;ab-n;hb-b;tb-n\n";
}