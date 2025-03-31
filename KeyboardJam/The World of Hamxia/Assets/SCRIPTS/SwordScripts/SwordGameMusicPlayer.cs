using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordGameMusicPlayer : MonoBehaviour
{
    private static SwordGameMusicPlayer instance = null;
    public static SwordGameMusicPlayer Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
