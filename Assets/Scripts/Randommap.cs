using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randommap : MonoBehaviour
{
    public GameObject map;

    public Vector3 zpos;

    public int mapnum = 20;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < mapnum; i++)
        {
            randomMap();

        }
    }
    // Update is called once per frame

    public void randomMap()
    {

        GameObject go = Instantiate(map, zpos, Quaternion.identity);
        zpos = go.transform.GetChild(1).transform.position;

    }

}
