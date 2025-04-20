using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;
    public bool stopTime;
    public bool wincheck;
    bool onoff;
    public GameObject curtain;
    public AudioSource wrong;
    public AudioClip wrongsfx;
    // Start is called before the first frame update
    void Start()
    {
        onoff = true;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        curtain = GameObject.Find("Trans");
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime -= Time.deltaTime;
        if (gameTime <= 0 && stopTime == false && onoff == true && curtain.GetComponent<Curtain>().stopTimer == false)
        {
            Debug.Log("timesup");
            wrong.clip = (wrongsfx);
            wrong.Play();
            stopTime = true;
            curtain.GetComponent<Curtain>().health -= 25;
            onoff = false;
            losegame();
        }
        if (stopTime == false)
        {
            timerSlider.value = time;
        }

        if (curtain.GetComponent<Curtain>().wincheck == true)
        {
            stopTime = true;
        }
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
