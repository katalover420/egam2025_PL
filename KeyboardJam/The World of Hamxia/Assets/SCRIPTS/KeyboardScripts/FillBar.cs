using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    public Image BarFill;
    public float Bar, MaxBar;
    public float Cost;
    public float Nothing;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Bar -= Nothing * Time.deltaTime;
        if (Bar < 0) Bar = 0;
        BarFill.fillAmount = Bar / MaxBar;
    }

}
