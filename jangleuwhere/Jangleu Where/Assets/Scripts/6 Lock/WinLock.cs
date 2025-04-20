using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLock : MonoBehaviour
{
    public GameObject curtain;
    public bool overlap;
    public int wincount;
    public int fail = 0;
    public bool wincheck;
    public Timer timeScript;
    public AudioSource correct;
    public AudioClip correctsfx;
    public AudioSource wrong;
    public AudioClip wrongsfx;
    public bool wcheck;
    public GameObject checkone;
    public GameObject checktwo;
    public GameObject checkthree;
    public GameObject checks;

    public GameObject locked;
    //public bool wincheck;
    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Trans");
        overlap = false;
        wincheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (wincount ==1)
        {
            checkone.SetActive(true);
        }
        if (wincount == 2)
        {
            checktwo.SetActive(true);
        }
        
        if (wincount >= 3)
        {
            checkthree.SetActive(true);
            wcheck = true;
            timeScript.stopTime = true;
            this.GetComponent<PolygonCollider2D>().enabled = false;
            correct.clip = (correctsfx);
            correct.Play();
            StartCoroutine(winning());
            Debug.Log("win!");
            wingame();
        }

        if (fail >= 1 && wcheck == false)
        {
            timeScript.stopTime = true;
            Debug.Log("LockLose");
            wrong.clip = (wrongsfx);
            wrong.Play();
            curtain.GetComponent<Curtain>().health -= 25;
            losegame();
            wcheck = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("win"))
        {
            overlap = true;
            Debug.Log("ovelaps");
            wincheck = true;

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
    void losegame()
    {

        if (curtain.GetComponent<Curtain>().health > 0)
        {
            StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());

        }
        // leucisSlide.value = 0.99999f;




    }
    public IEnumerator winning()
    {
        yield return new WaitForSeconds(0.5F);
        checks.SetActive(false);
        locked.SetActive(true);
    }
}
