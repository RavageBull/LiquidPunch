using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainConfig : MonoBehaviour
{
    void Start()
    {
        Terrain.activeTerrain.treeDistance = 10000;
    }

}
