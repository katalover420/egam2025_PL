using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManagerScript : MonoBehaviour
{
    
    public GameObject gameOverUI;
    public GhostScript ghostScript;
    public GameObject enemyPrefab;
    public int maxEnemy;
    public GameObject escapeUI;
    public SwordGameMusicPlayer bgmusic;




    void Start()
    {
        maxEnemy = 9;
        bgmusic = GetComponent<SwordGameMusicPlayer>();
    }
    void Update()
    {
        var enemies = GameObject.FindWithTag("enemy");
        if (enemies == null)
        {
            gameOverUI.SetActive(true);

        }
        
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pause();
            Debug.Log("hi");

        }
        //if (escapeUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        escapeUI.SetActive(false);

        //    }
            
           
        //}




    }

    public void pause()
    {
        if (escapeUI.activeSelf == false)
        {
            escapeUI.SetActive(true);
        }

        else
        {
            escapeUI.SetActive(false);
        }
    }

    public void mainmenu()
    {
        SceneManager.LoadScene("StartScreen");
        
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void levelTwo()
    {
        SceneManager.LoadScene("SwordLevel2");
    }

    public void levelThree() 
    {
        SceneManager.LoadScene("SwordLevel3");
    }

    public void levelOne()
    {
        SceneManager.LoadScene("SwordLevel1");
    }
}
