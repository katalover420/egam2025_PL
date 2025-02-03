using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterfaceScript : MonoBehaviour
{
    public int score;
    public TMP_Text scoreLabel;
    public int highScore;
    public TMP_Text highScoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = score.ToString();
        highScoreLabel.text = score.ToString();
        //AddScore(5);
    }

    public void AddScore (int number)
    {
        score +=number;
    }
}
