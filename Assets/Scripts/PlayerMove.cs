using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class PlayerMove : MonoBehaviour
{
    public GameObject GameManager;
    public int movespeed = 5;

    public float turnspeed = 20;
    public float leftrightspeed = 0.2f;

    //public Rigidbody rigid;

    public AIfollow ai;
    public float aiSpeed = 5;
    private float curDistance;

    public GameObject aiTransform;

    public GameObject losescreendisplay;

    [SerializeField] SkinnedMeshRenderer useSkin;
    [SerializeField] Material matSkin;

    [SerializeField] GameObject[] particles;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        //rigid = GetComponent<Rigidbody>();

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    public void Update()
    {


    }

    /// <summary>
    /// LateUpdate is called every frame, if the Behaviour is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    private void LateUpdate()
    {
        transform.Translate(Vector3.forward * movespeed * Time.deltaTime, Space.World);

        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        if (SwipeManager.swipeLeft)
        {
            Debug.Log("sang trai");
            if (this.gameObject.transform.position.x > -4.4)
            {
                transform.position += new Vector3(leftrightspeed * Time.deltaTime * -1, 0, 0);
                //Vector3 target = new Vector3(leftrightspeed * Time.deltaTime * -1, 0, 0);
                //transform.position += Vector3.Lerp(transform.position, target, Time.deltaTime);
                //rigid.velocity = Vector3.left * Time.deltaTime * leftrightspeed;

            }
        }
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        if (SwipeManager.swipeRight)
        {
            Debug.Log("sang phai");
            if (this.gameObject.transform.position.x < 4.4)
            {
                //Vector3 target = new Vector3(leftrightspeed * Time.deltaTime, 0, 0);
                //transform.position += Vector3.Lerp(transform.position, target, Time.deltaTime);
                transform.position += new Vector3(leftrightspeed * Time.deltaTime, 0, 0);
                //transform.Translate(Vector3.left * Time.deltaTime * leftrightspeed * -1);
                //rigid.velocity = Vector3.left * Time.deltaTime * leftrightspeed * -1;


            }
        }

        ai.Follow(transform.position, aiSpeed);


    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Vachdich")
        {
            Debug.Log("End Game");
            GameManager.GetComponent<Endrun>().enabled = true;

        }

        if (other.gameObject.tag == "CoinSpeed")
        {
            Debug.Log("Tang Toc");
            FindObjectOfType<AudioManager>().playSound("CoinPickup");
            playParticle(0);
            movespeed = 10;
            Destroy(other.gameObject);
            StartCoroutine(timespeed());
        }

        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Giam Toc");
            movespeed = 1;
            StartCoroutine(giamspeed());
        }


        if (other.gameObject.tag == "CoinMoney")
        {
            Debug.Log("Tang Coin");
            FindObjectOfType<AudioManager>().playSound("CoinPickup");
            playParticle(1);
            CoinCount.coinCount += 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Hoa")
        {
            Debug.Log("nhat duoc hoa");
            FindObjectOfType<AudioManager>().playSound("CoinPickup");
            useSkin.material = matSkin;

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Ai")
        {
            Debug.Log("Bi bat");
            FindObjectOfType<AudioManager>().playSound("EndMusic");
            losescreendisplay.SetActive(true);

        }
    }

    IEnumerator timespeed()
    {
        yield return new WaitForSeconds(1f);
        movespeed = 5;
    }

    IEnumerator giamspeed()
    {
        yield return new WaitForSeconds(1f);
        movespeed = 5;
    }

    IEnumerator playParticle(int index)
    {
        GameObject star = Instantiate(particles[index], transform.position, transform.rotation);
        star.GetComponentInChildren<ParticleSystem>().Play();
        yield return new WaitForSeconds(2f);
        Destroy(star);
    }



}
