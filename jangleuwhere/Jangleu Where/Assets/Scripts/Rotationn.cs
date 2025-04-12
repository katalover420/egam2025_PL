using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotationn : MonoBehaviour
{
    // Use this for initialization
    public float speed = 1;
    public float RotAngleZ = 45;
    public Rigidbody2D rb;
    public float Force;
    public bool isturn;
    public GameObject curtain;
    void Start()
    {
        isturn = true;
        curtain = GameObject.Find("Trans");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isturn == true)
        {

        float rY = Mathf.SmoothStep(0, RotAngleZ, Mathf.PingPong(Time.time * speed, 1));
        transform.rotation = Quaternion.Euler(0, 0, rY);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //rb.AddForce(transform.forward * Force);
            shoot();
            isturn = false;
        }
    }

    void shoot()
    {
        rb.AddForce(-transform.right * Force);
        // rb.AddForce(transform.forward * Force);



        //GetComponent<Rigidbody2D>().AddForce(currentEulerAngles * Force, ForceMode2D.Impulse);

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
        Destroy(GameObject.FindWithTag("win"));




    }

}
