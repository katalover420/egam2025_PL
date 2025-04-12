using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Curtain : MonoBehaviour
{
    public bool gamenext;

    public Animator animator;
    public List<string> SceneNames;
    public List<string> ScenesPlayed;
   // public List<int> availableScenes;
    //public List<int> playedScenes;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        gamenext = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamenext == true)
        {
            StartCoroutine(CurtainLowerRoutine());
        }
        if (SceneNames.Count <= 0)
        {
            SceneNames = ScenesPlayed;
            ScenesPlayed = new List<string>();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(CurtainLowerRoutine());
        }
    }

    public void startgame()
    {
        StartCoroutine(CurtainLowerRoutine());
    }
    public void LoadRandomScene()
    {
        if (SceneNames.Count > 0)
        {
            int no = Random.Range(0, SceneNames.Count);
            string str = SceneNames[no];

            SceneManager.LoadScene(str);
            SceneNames.RemoveAt(no);
            ScenesPlayed.Add(str);
        }
    }

    public void CurtainRise()
    {
        StartCoroutine(CurtainLowerRoutine());
    }
    public IEnumerator CurtainLowerRoutine()
    {
        gamenext = false;
        animator.SetBool("gameend", true);
        yield return new WaitForSeconds(3);
        LoadRandomScene();
        
        animator.SetBool("gameend", false);
        
        //yield return null;
    }
}
