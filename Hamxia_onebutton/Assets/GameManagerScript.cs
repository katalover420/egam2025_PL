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




    void Start()
    {
        maxEnemy = 9;
    }
    void Update()
    {
        var enemies = GameObject.FindWithTag("enemy");
        if (enemies == null)
        {
            gameOverUI.SetActive(true);

        }
        

        
        

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void levelTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void levelThree() 
    {
        SceneManager.LoadScene("Level3");
    }

    public void levelOne()
    {
        SceneManager.LoadScene("Level1");
    }
}
