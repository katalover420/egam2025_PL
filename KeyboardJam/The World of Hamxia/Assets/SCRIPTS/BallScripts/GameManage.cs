using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject escapeUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            pause();
            Debug.Log("hi");

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

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void win()
    {
        winScreen.SetActive(true);
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
