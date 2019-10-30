using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    [Range(3,20)]
    public int numberOfTilesOnXAxis;
    [Range(3, 20)]
    public int numberOfTilesOnYAxis;
    public int numberOfMines;
    public GameObject tilePrefab;
    public FieldBehaviour fieldBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateTiles(numberOfTilesOnXAxis, numberOfTilesOnYAxis, numberOfMines, tilePrefab);
    }


    void InstantiateTiles(int numberOfTilesOnXAxis, int numberOfTilesOnYAxis, int numberOfMines, GameObject tilePrefab)
    {
        float tileXSize = tilePrefab.GetComponent<TileBehavior>().GetTileXSize();
        float tileYSize = tilePrefab.GetComponent<TileBehavior>().GetTileYSize();
        int tileCount = 1;

        float offsetX = 0;
        if (ShouldHaveOffset(numberOfTilesOnXAxis)){
            offsetX = tileXSize/2;
        }

        float offsetY = 0;
        if (ShouldHaveOffset(numberOfTilesOnYAxis))
        {
            offsetY = tileYSize / 2;
        }

        int xStart = GetGridIteratorStart(numberOfTilesOnXAxis);
        int xEnd = GetGridIteratorEnd(numberOfTilesOnXAxis);

        int yStart = GetGridIteratorStart(numberOfTilesOnYAxis);
        int yEnd = GetGridIteratorEnd(numberOfTilesOnYAxis);
        List<Vector2> bombIndexes = GetBombIndexes(numberOfMines, xEnd, yEnd);
        Vector2 currentIndex =  new Vector2(0, 0);
        for (int y = yStart; y < yEnd; y++)
        {
            for (int x = xStart; x < xEnd; x++)
            {
                currentIndex.x = x;
                currentIndex.y = y;
                GameObject tile = Instantiate(tilePrefab, this.transform) as GameObject;
                tile.transform.position = new Vector3((tileXSize * x) + offsetX, (tileYSize * y) + offsetY);
                tile.name = string.Format("Tile {0}", tileCount);
                if (bombIndexes.Contains(currentIndex))
                {
                    tile.GetComponent<TileBehavior>().isMine = true;
                }
                tile.GetComponent<TileBehavior>().controller = fieldBehaviour;
                fieldBehaviour.tiles.Add(tile);
                tileCount++;
            }
        }
    }

    bool ShouldHaveOffset(int value)
    {
        return value % 2 == 0;
    }

    int GetGridIteratorStart(int value)
    {
        return -value/2;
    }

    int GetGridIteratorEnd(int value)
    {
        return value / 2 + value % 2;
    }

    List<Vector2> GetBombIndexes(int numberOfBombs, int lastXIndex, int lastYIndex)
    {
        List<Vector2> bombsIndex = new List<Vector2>(numberOfBombs-1);
        Debug.Assert(lastXIndex * lastYIndex <= numberOfBombs);

        while (numberOfBombs > 0) {
            Vector2 randomIndex = new Vector2(Random.Range(0, lastXIndex) ,Random.Range(0, lastYIndex));
            if (!bombsIndex.Contains(randomIndex))
            {
                numberOfBombs--;
                bombsIndex.Add(randomIndex);
            }
        }

        return bombsIndex;
    }

}
