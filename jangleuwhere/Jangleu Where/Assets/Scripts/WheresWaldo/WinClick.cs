using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinClick : MonoBehaviour
{
    public GameObject curtain;
    public bool overlap;
    public Timer timeScript;
    public bool lose;
    public AudioSource correct;
    public AudioClip correctsfx;
    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Trans");
        overlap = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnMouseDown()
    {
        if (overlap == true)
        {
            correct.clip = (correctsfx);
            correct.Play();
            timeScript.stopTime = true;
            Debug.Log("you win!");
            wingame();
        }
        
    }
    
    
    void wingame()
    {

        curtain.GetComponent<Curtain>().gamesWon++;
        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
        //Destroy(GameObject.FindWithTag("win"));




    }

    private void OnMouseOver()
    {
        overlap = true;
        //Debug.Log("ovelaps");
    }
}
