using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool onpress;
    public Rigidbody2D rb;
    //public float force;
    Vector3 direction = Vector3.left;
    public float speed;
    public float maxDelay = 0.5f;
    public GameObject curtain;
    public Timer timeScript;
    public AudioSource correct;
    public AudioClip correctsfx;
    bool wincheck;
    

    float mash;
    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Trans");
        onpress = false;
        mash = maxDelay;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(direction * speed * Time.deltaTime);
        if (onpress == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                onpress = true;
                mash = maxDelay;
                transform.Translate(direction * speed * Screen.width * Time.deltaTime);
                onpress = false;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Leucis") && wincheck == false)
        {
            wincheck = true;
            correct.clip = (correctsfx);
            correct.Play();
            timeScript.stopTime = true;
            Debug.Log("win");
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
