using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public GameObject gameOverUI;
    public GameObject winStateUi;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winStateUi.activeSelf == true)
        {
            Time.timeScale = 0;
        }

        else if (remainingTime > 0)
        {
            Time.timeScale = 1.0f;
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            Time.timeScale = 1.0f;
            remainingTime = 0;
            gameOverUI.SetActive(true);
            

        }

        
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
