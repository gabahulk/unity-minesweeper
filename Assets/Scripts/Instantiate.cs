using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public GameObject myPrefab;

    void Start()
    {
        for (int y = 0; y < 13; ++y)
        {
            for (int x = 0; x < 9; ++x)
            {
                var tile = Instantiate(myPrefab, new Vector3(x, y, 0), Quaternion.identity);
                tile.AddComponent<Element>();
            }
        }

    }


}
