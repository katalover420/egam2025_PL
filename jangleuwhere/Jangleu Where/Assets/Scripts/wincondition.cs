using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wincondition : MonoBehaviour
{
    public GameObject curtain;
    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Trans");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("win"))
        {
            Debug.Log("win!");
            wingame();
        }
    }

    void wingame()
    {

        curtain.GetComponent<Curtain>().gamesWon++;
        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
        //Destroy(GameObject.FindWithTag("win"));




    }
}
