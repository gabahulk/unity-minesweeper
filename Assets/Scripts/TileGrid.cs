using UnityEngine;
using System.Collections;

public class TileGrid
{
    public static int w = 13;
    public static int h = 9;
    public static Element[,] elements = new Element[w, h];

    public static void uncoverMines()
    {
        foreach (Element elem in elements)
            if (elem.isMine) elem.LoadTexture(0);
    }
}