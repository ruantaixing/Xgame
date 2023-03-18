using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefab;
    public GameObject currentTile;
    public GameObject dichTile;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnTile();
        }
        Instantiate(dichTile, currentTile.transform.GetChild(1).position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnTile()
    {
        int index = Random.Range(0, 4);
        currentTile = Instantiate(tilePrefab[index], currentTile.transform.GetChild(1).position, Quaternion.identity);
    }
}
