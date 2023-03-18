using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerOld : MonoBehaviour
{
    public GameObject[] tilePrefab;
    //public GameObject currentTile;
    public GameObject dichTile;
    Vector3 nextSpawnpoint;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(currentTile, nextSpawnpoint, Quaternion.identity);
        //nextSpawnpoint = currentTile.transform.GetChild(1).transform.position;
        Debug.Log(nextSpawnpoint);
        for (int i = 0; i < 10; i++)
        {
            spawnTile();

        }

        Instantiate(dichTile, nextSpawnpoint, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnTile()
    {
        int index = Random.Range(0, 4);
        GameObject Tile = Instantiate(tilePrefab[index], nextSpawnpoint, Quaternion.identity);
        Debug.Log(Tile.transform.GetChild(1).transform.position);
        nextSpawnpoint += Tile.transform.GetChild(1).transform.position;
        Debug.Log(nextSpawnpoint);
    }
}
