using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseState : MonoBehaviour
{
    public float time;
    public GameManage manageScript;
    public int scoreNumber;
    public TMP_Text scoreText;
    public GameObject seed1;
    public GameObject seed2;
    public GameObject seed3;
    public AudioClip nomSound;
    public AudioSource nomSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bounds"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("hai");
        }
        if(other.gameObject.CompareTag("spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        //if(other.gameObject.CompareTag("win"))
        //{
        //    manageScript.win();
        //}
        //if (other.gameObject.CompareTag("win"))
        //{
        //    time += Time.deltaTime;

        //    if (time >= 3)
        //    {
        //        manageScript.win();
        //    }

        //}
        


    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("win"))
        {
            Debug.Log("touch");
            time += Time.deltaTime;

            if (time >= 2)
            {
                manageScript.win();
            }

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("seed"))
        {
            scoreNumber++;
            scoreText.text = scoreNumber + "/3 Seeds Collected!";
            Destroy(seed1);
            nomSource.clip = (nomSound);
            nomSource.Play();

        }
        if (other.gameObject.CompareTag("seed2"))
        {
            scoreNumber++;
            scoreText.text = scoreNumber + "/3 Seeds Collected!";
            Destroy(seed2);
            nomSource.clip = (nomSound);
            nomSource.Play();
        }
        if (other.gameObject.CompareTag("seed3"))
        {
            scoreNumber++;
            scoreText.text = scoreNumber + "/3 Seeds Collected!";
            Destroy(seed3);
            nomSource.clip = (nomSound);
            nomSource.Play();

        }
    }


}
