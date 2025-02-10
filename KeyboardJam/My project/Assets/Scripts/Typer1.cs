using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TyperCN : MonoBehaviour
{
    public WordBank wordBank = null;
    public Text wordOutput = null;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    public Image BarFill;
    public float Bar, MaxBar;
    public float Add;
    public float Nothing;
    public GameObject gameOverUI;
    public GameObject winStateUI;
    public CameraShake shakeScript;
    public GameObject hearts;
    public AudioSource sfxSource;
    public AudioClip typeSound;
    public AudioSource sparkleSource;
    public AudioClip sfxSparkle;
    public AudioSource errorSource;
    public AudioClip sfxError;
   

    // Start is called before the first frame update
    private void Start()
    {
        SetCurrentWord();
    }

    // Update is called once per frame

    private void SetCurrentWord()
    {
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = remainingWord;
        hearts.SetActive(false);
    }
    private void Update()
    {
        CheckInput();
        if (Bar != MaxBar)
        {
            Bar -= Nothing * Time.deltaTime;
        }
        
        if (Bar < 0) 
        {
            Bar = 0;
            gameOverUI.SetActive(true);
            
            
        }
        BarFill.fillAmount = Bar / MaxBar;
    }
    

    private void CheckInput()
    {
        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;

            if(keysPressed.Length == 1)
                EnterLetter(keysPressed);
             
        }
    }

    void EnterLetter(string typedLetter)
    {
        if(IsCorrectLetter(typedLetter))
        {
            RemoveLetter();
            sfxSource.clip = (typeSound);
            sfxSource.Play();

            if (IsWordComplete())
            {
                SetCurrentWord();
                Debug.Log("working");
                Bar += Add;
                if(Bar >  MaxBar) 
                {
                    Bar = MaxBar;
                    winStateUI.SetActive(true);
                   

                }
                BarFill.fillAmount = Bar / MaxBar;
                hearts.SetActive(true);
                shakeScript.StartShake();
                sparkleSource.clip = (sfxSparkle);
                sparkleSource.Play();

                
            }
        }
        else
        {
            errorSource.clip = (sfxError);
            errorSource.Play();
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);

    }

    private bool IsWordComplete()
    {
        return remainingWord.Length == 0;
    }
}
