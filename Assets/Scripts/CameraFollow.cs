using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position - player.transform.rotation * dir;
        transform.LookAt(player);
    }
}
