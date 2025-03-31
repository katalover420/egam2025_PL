using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ballgame()
    {
        SceneManager.LoadScene("Level1");

    }
    public void swordgame()
    {
        SceneManager.LoadScene("SwordLevel1");
    }
    public void typergame()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void rhythmgame()
    {
        SceneManager.LoadScene("rhythmscene");
    }

    private void OnMouseOver()
    {
        //play animation

        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "Sword")
            {
            SceneManager.LoadScene("SwordLevel1");

            }
            if (gameObject.tag == "Typer")
            {
                SceneManager.LoadScene("StartScene");

            }
            if (gameObject.tag == "Ball")
            {
                SceneManager.LoadScene("Level1");

            }
            if (gameObject.tag == "Guqin")
            {
                SceneManager.LoadScene("rhythmscene");

            }

        }
    }

    
}
