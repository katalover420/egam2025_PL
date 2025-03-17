using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject platform;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Win()
    {
        platform.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        ball.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    public void levelTwo()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void Level6()
    {
        SceneManager.LoadScene("Level6");
    }
}
