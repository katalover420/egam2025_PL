using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Guy : MonoBehaviour
{
    public GameObject cross;
    public GameObject cross1;
    public GameObject cross2;
    public Animator animator;
    bool ishit;
    int deathPosition = 0;
    public score scoreScript;
    public Player playerScript;
    float time;
    //int deathscore;
    // Start is called before the first frame update
    void Start()
    {
      //  ishit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreScript.deathscore==1)
        {
            cross.gameObject.SetActive(true);

        }
        if (scoreScript.deathscore == 2)
        {
            cross1.gameObject.SetActive(true);
               
        }
        if (scoreScript.deathscore == 3)
        {
            time = Time.deltaTime;
            cross2.gameObject.SetActive(true);
            if (time > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
            //if (playerScript.position == 1)
            //{
            //    scoreScript.deathscore = 0;
            //    cross.gameObject.SetActive(false);
            //    cross1.gameObject.SetActive(false);
            //    cross2.gameObject.SetActive(false);
            //}

        }
        //if (deathPosition > 0 && cross.gameObject.activeSelf && cross1.gameObject.activeSelf)
        //{
        //    cross2.gameObject.SetActive(true);
        //}
        // if (cross2.gameObject.activeSelf)
        //{
        //    scoreScript.realScore = 0;
        //}

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        deathPosition++;
        scoreScript.deathscore += 1;
        animator.SetInteger("DeathPosition", deathPosition);
       // ishit = true;
        //ishit = true;
        //animator.SetBool("hit", ishit);
        Debug.Log("hello");
    }
}
