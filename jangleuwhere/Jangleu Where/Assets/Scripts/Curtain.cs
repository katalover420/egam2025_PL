using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;

public class Curtain : MonoBehaviour
{
    //public bool gamenext;
    bool stopTime;

    public Animator animator;
    public List<string> SceneNames;
    public List<string> ScenesPlayed;
    public float gameTimer = 100;
    public int seconds;
    public bool costart;
    public TMP_Text timerText;

    public int gamesWon;
    public TMP_Text scoreText;


  
    void Start()
    {
        DontDestroyOnLoad(this);
        stopTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (costart == true)
        {
            gameTimer -= Time.deltaTime;
            seconds = (int)(gameTimer);
        }
        scoreText.text = gamesWon.ToString();

        if (gameTimer <= 0)
        {
            stopTime = true;
        }
        if (stopTime == false)
        {
            timerText.text = seconds.ToString();
        }

        // if (StartCoroutine(CurtainLowerRoutine()))
        if (SceneNames.Count <= 0)
        {
            SceneNames = ScenesPlayed;
            ScenesPlayed = new List<string>();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CurtainLowerRoutine());
        }
    }

    public void startgame()
    {
        StartCoroutine(CurtainLowerRoutine());
    }
    public void LoadRandomScene()
    {
        if (SceneNames.Count > 0)
        {
            int no = Random.Range(0, SceneNames.Count);
            string str = SceneNames[no];

            SceneManager.LoadScene(str);
            SceneNames.RemoveAt(no);
            ScenesPlayed.Add(str);
        }
    }

    public void CurtainRise()
    {
        StartCoroutine(CurtainLowerRoutine());
    }
    public IEnumerator CurtainLowerRoutine()
    {

        costart = true;
        animator.SetBool("gameend", true);
        yield return new WaitForSeconds(2);
        LoadRandomScene();
        
        animator.SetBool("gameend", false);
        
        //yield return null;
    }
}
