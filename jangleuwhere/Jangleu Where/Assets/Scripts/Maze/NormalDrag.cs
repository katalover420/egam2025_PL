using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDrag : MonoBehaviour
{
    bool MoveRestricted = false;
    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject curtain;
    bool wincheck;
    public Timer timeScript;
    public AudioSource correct;
    public AudioClip correctsfx;
    public AudioSource wrong;
    public AudioClip wrongsfx;
    private void Start()
    {
        curtain = GameObject.Find("Trans");
        
        wincheck = false;
    }

    private void Update()
    {
        
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        //curPosition.y = 0;
        transform.position = curPosition;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.CompareTag("lose"))
        {
            wrong.clip = (wrongsfx);
            wrong.Play();
            timeScript.stopTime = true;
            this.GetComponent<CircleCollider2D>().enabled = false;
            Debug.Log("MazeLose");
            curtain.GetComponent<Curtain>().health -= 25;
            losegame();
        }
        if (other.gameObject.CompareTag("win"))
        {
            correct.clip = (correctsfx);
            correct.Play();
            timeScript.stopTime = true;
            Debug.Log("Win!");
            wingame();
        }
    }

    void wingame()
    {

        curtain.GetComponent<Curtain>().gamesWon++;
        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
        wincheck = true;
        //Destroy(GameObject.FindWithTag("win"));




    }
    void losegame()
    {

        if (wincheck == false && curtain.GetComponent<Curtain>().health > 0)
        {
        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());

        }
        // leucisSlide.value = 0.99999f;




    }
}
