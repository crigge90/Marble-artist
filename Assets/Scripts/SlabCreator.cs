using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlabCreator : MonoBehaviour {

    public GameObject blockPrefab;
    public int slabHeight = 20;
    public int slabWidth = 10;
    public int slabDepth = 10;
    public float[][][] blockArray;

    void Start ()
    {
        for (int i = 0; i < slabWidth; i++)
        {
            for (int j = 0; j < slabDepth; j++)
            {
                for (int k = 0; k < slabHeight; k++)
                {
                    Instantiate(blockPrefab, new Vector3(i, k, j), Quaternion.identity);
                    
                }
            }
        }
	}
}
