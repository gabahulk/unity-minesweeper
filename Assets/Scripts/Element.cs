using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Element : MonoBehaviour
{

    public bool isMine;
    public List<Sprite> tiles;

    public Sprite mineSprite;

    void Start()
    {
        isMine = Random.value < 0.15;

        // int x = (int)transform.position.x;
        // int y = (int)transform.position.y;
        // TileGrid.elements[x, y] = this;
    }

    public void LoadTexture(int adjacentCount)
    {
        if (isMine)
            GetComponent<SpriteRenderer>().sprite = mineSprite;
        else
            GetComponent<SpriteRenderer>().sprite = tiles[adjacentCount];
    }

    void OnMouseUpAsButton()
    {
        if (isMine)
        {
            // TileGrid.uncoverMines();

            LoadTexture(2);
            Debug.Log("Game...Over!");
        }
        else
        {
            Debug.Log("show blocks now");
            // TODO: show mine numbers
        }

    }
}