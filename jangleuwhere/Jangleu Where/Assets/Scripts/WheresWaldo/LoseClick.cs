using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseClick : MonoBehaviour
{
    public GameObject curtain;
    public bool overlap;
    public Timer timeScript;
    
    public bool lose;
    
    public AudioSource wrong;
    public AudioClip wrongsfx;
    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Trans");
        overlap = false;
        lose = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (lose == true)
        {
            wrong.clip = (wrongsfx);
            wrong.Play();
            timeScript.stopTime = true;
            Debug.Log("waldoLose");
            curtain.GetComponent<Curtain>().health -= 25;
            losegame();
        }

    }
   

    
    void losegame()
    {

        if (curtain.GetComponent<Curtain>().health > 0)
        {
            StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());

        }
        // leucisSlide.value = 0.99999f;




    }

    private void OnMouseOver()
    {
        lose = true;
        Debug.Log("loser!");
    }
}
