using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controlls the tiles behavior when it's cliked.
/// </summary>
public class FieldBehaviour : MonoBehaviour
{
    public List<GameObject> tiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private List<TileBehavior> FindAdjacentTiles()
    {
        return new List<TileBehavior>();
    }
}
