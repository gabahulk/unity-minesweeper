using UnityEngine;
using System.Collections;

public class Element : MonoBehaviour
{

    public bool mine;
    public Sprite[] emptyTextures;
    public Sprite mineTexture;

    void Start()
    {
        mine = Random.value < 0.15;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Grid.elements[x, y] = this;
    }

    public void loadTexture(int adjacentCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
    }

    void OnMouseUpAsButton()
    {
        if (mine)
        {
            Grid.uncoverMines();

            print("Game...Over!");
        }
        else
        {
            // TODO: show mine numbers
        }

    }
}