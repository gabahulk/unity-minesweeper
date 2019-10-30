using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public TileInfo tileInfo;
    public FieldBehaviour controller;
    public bool isMine;

    private SpriteRenderer spriteRenderer;
    private bool commitingToSlot = false;
    private void Awake()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = tileInfo.tileTypes.getSpriteByName("Tile");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Gets the size of the first sprite of tileInfo on the x axis
    /// </summary>
    /// <returns>Size of the first sprite of tileInfo on the x axis</returns>
    public float GetTileXSize()
    {
        return tileInfo.tileTypes.getSpriteByName("Tile").bounds.size.x;
    }

    /// <summary>
    /// Gets the size of the first sprite of tileInfo on the y axis
    /// </summary>
    /// <returns>Size of the first sprite of tileInfo on the y axis</returns>
    public float GetTileYSize()
    {
        return tileInfo.tileTypes.getSpriteByName("Tile").bounds.size.x;
    }

    public void OnMouseDown()
    {
        // change the tile
        spriteRenderer.color = Color.gray;
        commitingToSlot = true;
    }

    public void OnMouseExit()
    {
        // change the tile
        commitingToSlot = false;
        spriteRenderer.color = Color.white;
    }

    public void OnMouseUp()
    {
        spriteRenderer.color = Color.white;
        if (commitingToSlot)
        {
            if (isMine)
            {
            }
            else
            {

            }
        }
    }
}
