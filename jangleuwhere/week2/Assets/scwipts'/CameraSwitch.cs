using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera main;

    public Camera other;
  
    void Start()
    {
        main.enabled = true;
        other.enabled = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            main.enabled = !main.enabled;
            other.enabled = !other.enabled;

        }
    }
}
