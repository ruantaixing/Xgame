using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotatespeed = 90;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotatespeed * Time.deltaTime, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
