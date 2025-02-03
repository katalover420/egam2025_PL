using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordSpawner : MonoBehaviour
{
    public bool isDead;
    public GameObject sword;
    public SwordPhysics SwordPhysics;
    public Slider forceUI;
    public float Force;


    // Start is called before the first frame update
    void Start()
    {
        sword = GameObject.Find("sword");
    }

    // Update is called once per frame
    void Update()
    {
        if (sword.activeInHierarchy ==false)
        {
            Vector3 SpawnPosition = new Vector3(0, -3, 0);
            Instantiate(sword, SpawnPosition, Quaternion.identity);
            sword.SetActive(true);
            
        }
    }
}
