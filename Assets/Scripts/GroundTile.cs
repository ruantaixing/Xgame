using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclespreb;
    public Transform[] spawnpos;

    //enemy
    public GameObject enemy;
    public Transform[] spawnenemypos;
    public float spawntime = 5;
    private float time = 0;

    //coin
    [SerializeField] private GameObject coinPrefab;

    //coinspeed
    [SerializeField] private GameObject coinspeedPrefab;

    //hoa
    [SerializeField] private GameObject hoaPrefab;


    // Start is called before the first frame update
    void Start()
    {
        spawnObstacles();
        spawnCoin();
        spawnCoinspeed();
        spawnHoa();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        if (time > spawntime)
        {
            int index = Random.Range(0, 3);
            GameObject en = Instantiate(enemy, spawnenemypos[index]);
            Destroy(en, 125f);
            time = 0f;
        }
        time += Time.deltaTime * .5f;
    }

    // Update is called once per frame
    public void spawnObstacles()
    {
        int index = Random.Range(0, 3);
        int obstaclespoints = Random.Range(2, 5);
        Transform spointspawn = transform.GetChild(obstaclespoints).transform;
        GameObject ep = Instantiate(obstaclespreb[index], spointspawn.position, Quaternion.identity, transform);
        Destroy(ep, 125f);
    }


    //lay vi tri coin
    Vector3 randomCoin(Collider collider)
    {
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x),
        Random.Range(collider.bounds.min.y, collider.bounds.max.y),
        Random.Range(collider.bounds.min.z, collider.bounds.max.z));

        if (point != collider.ClosestPoint(point))
        {
            point = randomCoin(collider);
        }
        point.y = 1;
        return point;

    }
    //tao ngau nhien Coin
    public void spawnCoin()
    {
        int index = 5;
        for (int i = 0; i < index; i++)
        {
            GameObject co = Instantiate(coinPrefab, transform);
            co.transform.position = randomCoin(GetComponent<Collider>());
            Destroy(co, 60f);
        }
    }

    //tao ngau nhien CoinSpeed
    public void spawnCoinspeed()
    {
        int index = 2;
        for (int i = 0; i < index; i++)
        {
            GameObject co = Instantiate(coinspeedPrefab, transform);
            co.transform.position = randomCoin(GetComponent<Collider>());
            Destroy(co, 60f);
        }
    }

    //tao ngau nhien hoa
    public void spawnHoa()
    {
        int index = 2;
        for (int i = 0; i < index; i++)
        {
            GameObject co = Instantiate(hoaPrefab, transform);
            co.transform.position = randomCoin(GetComponent<Collider>());
            Destroy(co, 60f);
        }
    }
}
