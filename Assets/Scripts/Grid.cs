using UnityEngine;
using System.Collections;

public class Grid
{
    public static int w = 20;
    public static int h = 20;
    public static Element[,] elements = new Element[w, h];

    public static void uncoverMines()
    {
        foreach (Element elem in elements)
            if (elem.mine) elem.loadTexture(0);
    }
}