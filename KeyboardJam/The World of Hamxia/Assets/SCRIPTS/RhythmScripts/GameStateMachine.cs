using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameStateMachine : MonoBehaviour
{
    public States state;
    public GameObject gameStart;
    public float gameTimer;
    public GameObject gameOverUI;
    public GameObject escapeUI;
    public enum States
  
    {
        GameOn, //0
        GameTransition, //1
        GameEnd //2
    }
    // Start is called before the first frame update
    void Start()
    {
        //SetState(state);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pause();
            Debug.Log("hi");

        }
        gameTimer += Time.deltaTime;
        switch (state)
        {
            case States.GameOn:
                GameOn();
                break;

            case States.GameTransition:
                GameTransition();
                break;

            case States.GameEnd:
                GameEnd();
                break;

        }
        //if (gameTimer >= 80)
        //{
        //    gameOverUI.SetActive(true);
        //}

        if (gameStart.activeSelf == false)
        {
            Time.timeScale = 1;
            if (gameTimer >= 67)
            {
                gameOverUI.SetActive(true);
            }
        }
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

    void GameOn()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gameStart.SetActive(false);
            Time.timeScale = 1;

            if(gameTimer >= 5)
            {
                state = States.GameTransition;
            }
            
        }
        
    }

    void GameTransition()
    {
        
            gameOverUI.SetActive(true);
        
    }

    void GameEnd()
    {

    }

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
