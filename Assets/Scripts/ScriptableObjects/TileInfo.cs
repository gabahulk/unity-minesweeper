using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="New Tile", menuName ="Mine Tile")]
/* 
 * The tile scriptable object. This class holds how the images of tiles will be stored.
 * Maybe a bit of over-engeneering, but now you can make diferent types of tiles!
 */
public class TileInfo : ScriptableObject
{
    [System.Serializable]
    public struct TileType
    {
        public string name;
        public Sprite image;
    }

    [System.Serializable]
    public class TileTypes
    {
        public TileType[] typeList;
        
        public Sprite getSpriteByName(string name)
        {
            foreach (var tileType in typeList)
            {
                if (tileType.name == name)
                {
                    return tileType.image;
                }
            }

            return null;
        }
    }

    public TileTypes tileTypes;
}
