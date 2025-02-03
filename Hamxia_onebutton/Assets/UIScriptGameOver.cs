using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIScriptGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public int highScore;
    public TMP_Text highScoreLabel;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highScoreLabel.text = highScore.ToString();
        //AddScore(5);
    }

    public void AddScore(int number)
    {
        highScore += number;
    }
}
