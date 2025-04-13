using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;
    bool stopTime;
    bool wincheck;
    public GameObject curtain;
    // Start is called before the first frame update
    void Start()
    {
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        curtain = GameObject.Find("Trans");
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime -= Time.deltaTime;
        if (gameTime <= 0 && wincheck == false)
        {
            stopTime = true;
            losegame();
        }
        if (stopTime == false)
        {
            timerSlider.value = time;
        }
    }

    void losegame()
    {


        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
        // leucisSlide.value = 0.99999f;




    }
}
