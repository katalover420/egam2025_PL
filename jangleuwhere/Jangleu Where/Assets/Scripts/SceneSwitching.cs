using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitching : MonoBehaviour
{
    public List<string> SceneNames;
    public List<string> ScenesPlayed;
    public List<int> availableScenes;
    public List<int> playedScenes;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.E))
        {
            LoadRandomScene();
        }
        if (SceneNames.Count <= 0)
        {
            SceneNames = ScenesPlayed;
            ScenesPlayed = new List<string>();
        }
        
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
}
