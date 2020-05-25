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
        //LoadFromPath();
    }

    public static int[,] LoadFromPath(string path = @"C:\repos\Rogal\Data\", int sampleNumber = 0) {
        
        using(StreamReader reader = new StreamReader(@"Data\Sample0.txt")) {
            string firstLine = reader.ReadLine();
            string secondLine = reader.ReadLine();
            string remaining = reader.ReadToEnd();
            string[] stringMapArray = remaining.Split(' ', '\n');
            string[] config = secondLine.Split(' ');
            int width = int.Parse(config[0]);
            int height = int.Parse(config[1]);
            Debug.Log(width);
            Debug.Log(height);
            int[,] map = new int[width,height];
            int i = 0;
            for(int y = 0; y<height; y++) {
                for(int x=0; x<width; x++) {
                    map[x, y] = int.Parse(stringMapArray[i]);
                    i++;
                }
            }
            return map;
        }
        return null;
    }
}
