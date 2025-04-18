using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndScript : MonoBehaviour
{
    public GameObject curtain;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        curtain = GameObject.Find("Trans");
        scoreText.text = curtain.GetComponent<Curtain>().gamesWon.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
