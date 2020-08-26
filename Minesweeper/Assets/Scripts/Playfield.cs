using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playfield
{
    public static int w = 10;
    public static int h = 13;
    public static Element[,] elements = new Element[w, h];

    public static void UncoverMines()
    {
        foreach (Element element in elements)
            if (element.mine)
                element.LoadTexture(0);
    }

    public static bool IsMineAt(int x, int y)
    {
        if (IsInsideGrid(x, y))
            return elements[x, y].mine;
        return false;
    }

    public static int CountAdjacentMines(int x, int y)
    {
        int count = 0;

        if (IsMineAt(x, y + 1)) ++count;        // top
        if (IsMineAt(x + 1, y + 1)) ++count;    // top right
        if (IsMineAt(x + 1, y)) ++count;        // right
        if (IsMineAt(x + 1, y - 1)) ++count;    // bottom right
        if (IsMineAt(x, y - 1)) ++count;        // bottom
        if (IsMineAt(x - 1, y - 1)) ++count;    // bottom left
        if (IsMineAt(x - 1, y)) ++count;        // left
        if (IsMineAt(x - 1, y + 1)) ++count;    // top-left

        return count;
    }

    public static void FloodFillUncover(int x, int y, bool[,] visited)
    {
        if (IsInsideGrid(x, y))
        {

            if (visited[x, y])
                return;

            int adjacentMinesCount = CountAdjacentMines(x, y);

            elements[x, y].LoadTexture(adjacentMinesCount);

            if (adjacentMinesCount > 0)
                return;

            visited[x, y] = true;

            FloodFillUncover(x - 1, y, visited);
            FloodFillUncover(x + 1, y, visited);
            FloodFillUncover(x, y - 1, visited);
            FloodFillUncover(x, y + 1, visited);
        }
    }

    public static bool IsFinished()
    {
        foreach (Element element in elements)
            if (element.IsCovered() && !element.mine)
                return false;

        return true;
    }

    static bool IsInsideGrid(int x, int y)
    {
        return x >= 0 && y >= 0 && x < w && y < h;
    }
}
