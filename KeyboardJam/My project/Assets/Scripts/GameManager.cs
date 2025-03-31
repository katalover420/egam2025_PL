using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public AudioSource loseSource;
    public AudioClip sfxLose;
    public GameObject gameOverUI;
    public Typer typeScript;
    public bool audioPlayed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeSelf == true && !audioPlayed)
        {
            loseSource.clip = (sfxLose);
            loseSource.Play();
            audioPlayed = true;
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    public void play()
    {
       SceneManager.LoadScene("keyboardlevel");
    }

    public void title()
    {
        SceneManager.LoadScene("StartScene");
    }
}
