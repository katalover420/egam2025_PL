using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Curtain : MonoBehaviour
{
    //public bool gamenext;
    public bool stopTimer;

    public Animator animator;
    public List<string> SceneNames;
    public List<string> ScenesPlayed;
    public float gameTimer = 100;
    public int seconds;
    public bool costart;
    public TMP_Text timerText;
    public GameObject timer;

    public float health;
    public float maxHealth;
    public Image healthBar;
    public GameObject BGM;
    public GameObject winUI;

    public int gamesWon;
    public TMP_Text scoreText;
    public GameObject loseUI;

    public GameObject fasterone;


  
    void Start()
    {
        timer = GameObject.Find("Timer");
        maxHealth = health;
        DontDestroyOnLoad(this);
        stopTimer = false;
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

        if (gamesWon >= 0)
        {
            Time.timeScale = 1f;
        }

        if (gamesWon >= 5)
        {
            Time.timeScale = 1.3f;
            StartCoroutine(Faster());
        }

        if (gamesWon >= 10)
        {
            Time.timeScale = 1.6f;
        }

        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            StartCoroutine(CurtainLoseRoutine());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CurtainWinRoutine());
        }

        if (gameTimer <= 0)
        {
            
            stopTimer = true;
            StartCoroutine(CurtainWinRoutine());
            //Destroy(this.gameObject);
        }
        if (stopTimer == false)
        {
            timerText.text = seconds.ToString();
        }

        // if (StartCoroutine(CurtainLowerRoutine()))
        if (SceneNames.Count <= 0)
        {
            SceneNames = ScenesPlayed;
            ScenesPlayed = new List<string>();
        }
        
    }

    public void startgame()
    {
        StartCoroutine(CurtainLowerRoutine());
        BGM.SetActive(true);
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

    public IEnumerator Restart()
    {
        animator.SetBool("gameend", true);
        SceneManager.LoadScene("SampleScene");
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("gameend", false);
        
        Destroy(this.gameObject);
        yield return null;
    }

    public void RestartButton()
    {
        StartCoroutine(Restart());
    }

    public void CurtainRise()
    {
        StartCoroutine(CurtainLowerRoutine());
    }
    public IEnumerator CurtainLowerRoutine()
    {
        if (gameTimer > 0)
        {

        costart = true;
        animator.SetBool("gameend", true);
        yield return new WaitForSeconds(2);
        LoadRandomScene();
        
        animator.SetBool("gameend", false);
        }
        
        //yield return null;
    }

    public IEnumerator CurtainLoseRoutine()
    {

        costart = false;
        animator.SetBool("gameend", true);
        loseUI.SetActive(true);
        
        yield return null;

        //yield return null;
    }

    public IEnumerator CurtainWinRoutine()
    {

        costart = false;
        animator.SetBool("gameend", true);
        winUI.SetActive(true);

        yield return null;

        //yield return null;
    }

    public IEnumerator Faster()
    {
        fasterone.SetActive(true);
        yield return new WaitForSeconds(4);
        fasterone.SetActive(false);
    }
}
