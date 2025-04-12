using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueCheck : MonoBehaviour
{
    public Slider timerSlider;
    public Slider leucisSlide;
    public Slider rajangSlide;
    public GameObject curtain;
    //public Curtain curtainScript;

    public float gameTime;
    bool stopTime;
    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Trans");
        //curtainScript = GetComponent(Curtain)
        stopTime = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;
        if (leucisSlide.value == 1 && rajangSlide.value == 1)
        {
            StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
            //curtainScript.gamenext = true;
        }

        if (gameTime <= 0)
        {
            stopTime = true;
        }
        if (stopTime == false)
        {
            timerSlider.value = time;
        }
    }
}
