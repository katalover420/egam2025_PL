using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseClick : MonoBehaviour
{
    public GameObject curtain;
    public bool overlap;
    
    public bool lose;
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
            Debug.Log("you lose!!!");
            wingame();
        }

    }
   

    void wingame()
    {

        //curtain.GetComponent<Curtain>().gamesWon++;
        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
        //Destroy(GameObject.FindWithTag("win"));




    }

    private void OnMouseOver()
    {
        lose = true;
        Debug.Log("loser!");
    }
}
