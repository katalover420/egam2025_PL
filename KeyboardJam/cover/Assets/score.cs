using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    public TMP_Text scoreText;
    public int hit;
    public int realScore;
    public int deathscore;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == 3)
        {
            realScore++;
            hit = 0;
            scoreText.text = "" + realScore;
        }

        scoreText.text = "" + realScore;

        if (deathscore == 3)
        {
            time += Time.deltaTime;
          
            if (time > 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            }
        }
    }
    public void AddScore(int number)
    {
        realScore += number;
    }

}
