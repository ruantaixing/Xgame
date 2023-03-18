using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIfollow : MonoBehaviour
{
    public float curdis;
    public Transform Ai;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Follow(Vector3 pos, float speed)
    {
        Vector3 position = pos - Vector3.forward * curdis;
        Ai.position = Vector3.Lerp(Ai.position, position, Time.deltaTime * speed / curdis);

    }
}
