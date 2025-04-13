using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinClick : MonoBehaviour
{
    public GameObject curtain;
    public bool overlap;
    
    public bool lose;
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
            Debug.Log("you win!");
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
        if (other.gameObject.CompareTag("lose"))
        {
            lose = true;
            Debug.Log("loser!");

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        overlap = false;
        lose = false;
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
        Debug.Log("ovelaps");
    }
}
