using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using System.Linq;

public static class StreamIO
{
    static string path = "Data/";
    
    public static void SaveDataToFile(int[,] map, int height, int width, string seed, int programIteration) {
        StreamWriter writer = new StreamWriter(path + "Sample" + programIteration.ToString() + ".txt", true);
        writer.WriteLine("WIDTH " + "HEIGHT " + "SEED");
        writer.WriteLine(width.ToString() + " " + height.ToString() + " " + seed.ToString());
        StringBuilder builder = new StringBuilder();
        for (int y = 0; y < height; y++) {
            for (int x = 0; x < width; x++) {
                builder.Append(map[x, y].ToString() + " ");
            }
            builder.Remove(builder.Length - 1, 1);
            writer.WriteLine(builder);
            builder = new StringBuilder();
        }
        writer.Close();
        LoadFromPath(path, programIteration);
    }

    public static int[,] LoadFromPath(string path, int sampleNumber) {
        
        string input = File.ReadAllText(path + "Sample" + sampleNumber.ToString()).Skip(1).ToString();
        Debug.Log(input);
        int x = 0, y = 0;
        foreach(var row in input.Split('\n')) {
            foreach( var col in row.Trim(' ')) {

            }
        }
        return null;
    }
}
