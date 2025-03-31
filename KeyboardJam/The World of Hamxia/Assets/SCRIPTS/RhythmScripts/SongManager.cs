using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;
    public static SongManager instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentCombo;
    public int maxCombo = 0;

    public TMP_Text scoreText;
    public TMP_Text comboText;
    public TMP_Text maxComboText;

    public AudioClip noteSound;
    public AudioSource noteSource;
    public AudioClip errorSound;
    public AudioSource errorSource;
    public Animator animator;
    public AttackOne attackscript;
    public Mana manaScript;
    public TMP_Text highScore;
    //public TMP_Text maxCombo;


    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;
        scoreText.text = "Score: 0";
        comboText.text = "Combo: 0";
        animator.SetBool("Fail", false);

    }

    // Update is called once per frame
    void Update()
    {
        maxComboText.text = "Max Combo: " + maxCombo + "/59";
        highScore.text = "Score: " + currentScore;
        scoreText.text = "Score: " + currentScore;
        if (!startPlaying)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }
        
    }

    public void NoteHit()
    {
        attackscript.clickedString += 1;
        noteSource.clip = (noteSound);
        noteSource.Play();
        Debug.Log("hit on time");
       currentScore += scorePerNote;
        currentCombo += 1;
        scoreText.text = "Score: " + currentScore;
        comboText.text = "Combo: " + currentCombo;
        if(currentCombo >= 5)
        {
            animator.SetBool("GoodCombo", true);
        }
        manaScript.mana += 20;
        if (currentCombo > maxCombo)
        {
            maxCombo = currentCombo;
        }

    }

    //public void NormalHit()
    //{
    //    currentScore += scorePerNote;
    //    NoteHit();
    //}

    //public void GoodHit()
    //{
    //    currentScore += scorePerGoodNote;
    //    NoteHit();
    //}

    //public void PerfectHit()
    //{
    //    currentScore += scorePerPerfectNote;
    //    NoteHit();
    //}

    public void NoteMissed()
    {
        attackscript.clickedString = 0;
        Debug.Log("missed");
        currentCombo = 0;
        animator.SetBool("Fail", true);
        animator.SetBool("GoodCombo", false);
        manaScript.mana = 0;
    }
}
