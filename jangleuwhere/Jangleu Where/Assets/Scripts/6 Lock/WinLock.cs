using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLock : MonoBehaviour
{
    public GameObject curtain;
    public bool overlap;
    public int wincount;
    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Trans");
        overlap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wincount >= 3)
        {
            Debug.Log("win!");
            wingame();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("win"))
        {
            overlap = true;
            Debug.Log("ovelaps");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        overlap = false;
    }

    void wingame()
    {

        curtain.GetComponent<Curtain>().gamesWon++;
        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
        wincount = 0;




    }
}
