using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public static int coinCount;
    public GameObject coincountDisplay;

    // Update is called once per frame
    void Update()
    {
        coincountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
