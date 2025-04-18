using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    float x;
    float y;
    float z;
    Vector3 currentEulerAngles;
    public float rotationSpeed = 100;

    public float speed = 1;
    public float RotAngleZ = 45;
    public Rigidbody2D rb;
    public float Force;
    public bool isturn;
    public GameObject curtain;
    public WinLock winScript;


    
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

            //z = 1 - z;



            currentEulerAngles += new Vector3(x, y, -1) * Time.deltaTime * rotationSpeed;

            transform.eulerAngles = currentEulerAngles;

        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            isturn = !isturn;
            if (winScript.overlap == true)
            {
                winScript.wincount += 1;
            }

            if (winScript.overlap == false)
            {
                winScript.fail += 1;
            }
            


        }

        

        if (isturn == false)
        {
            //z =+ 1;



            currentEulerAngles += new Vector3(x, y, 1) * Time.deltaTime * rotationSpeed;

            transform.eulerAngles = currentEulerAngles;
        }
    }

    

    

    void wingame()
    {

        curtain.GetComponent<Curtain>().gamesWon++;
        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
        Destroy(GameObject.FindWithTag("win"));




    }

}
