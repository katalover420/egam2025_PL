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
    bool wincheck;
    bool onoff;

    public AudioSource correct;
    public AudioClip correctsfx;
    public AudioSource wrong;
    public AudioClip wrongsfx;
    //public Curtain curtainScript;

    public float gameTime;
    bool stopTime;
    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Trans");
        //curtainScript = GetComponent(Curtain)
        stopTime = false;
        wincheck = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime -= Time.deltaTime;
        if (leucisSlide.value == 1 && rajangSlide.value == 1)
        {
            correct.clip = (correctsfx);
            correct.Play();
            stopTime = true;
            wingame();
            wincheck = true;
        }

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
    }

    void wingame()
    {
         
            curtain.GetComponent<Curtain>().gamesWon ++;
            StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
            leucisSlide.value = 0.99999f;


            
        
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
