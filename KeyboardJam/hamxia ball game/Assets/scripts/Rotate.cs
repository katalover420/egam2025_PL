using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 500;
    Vector3 currentEulerAngles;
    float x;
    float y;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            //z = 1 - z;



            //currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;

            //transform.eulerAngles = currentEulerAngles;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
            //z = 1 + z;

            //currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;

            //transform.eulerAngles = currentEulerAngles;

        }
    }
}
