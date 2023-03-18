using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Endrun : MonoBehaviour
{
    public GameObject liveCoin;
    public GameObject endscreendisplay;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endgame());
    }


    IEnumerator endgame()
    {
        yield return new WaitForSeconds(2f);
        player.GetComponent<PlayerMove>().enabled = false;
        liveCoin.SetActive(false);
        //FindObjectOfType<AudioManager>().playSound
        endscreendisplay.SetActive(true);
        yield return new WaitForSeconds(2f);
        int randomscene = Random.Range(0, 2);
        SceneManager.LoadScene(randomscene);
    }
}
