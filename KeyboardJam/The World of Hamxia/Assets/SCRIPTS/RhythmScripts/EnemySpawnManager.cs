using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float gapTimer;
    public int patternSwap;
    public int minPattern;
    public int maxPattern;
    public float spawnTime;


    private void Awake()
    {
        minPattern = 1;
        maxPattern = 3;
        patternSwap = 1;
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
    

    }

    void EnemySwap()
    {
        gapTimer += Time.deltaTime;

        if (gapTimer >= spawnTime)
        {
            gapTimer = 0;
            patternSwap = Random.Range(minPattern, maxPattern);
        }

    }

    void PickUp()
    {
        
            if (patternSwap == 1)
            {
                enemy1.SetActive(true);
                enemy2.SetActive(false);
                enemy3.SetActive(false);

            }
            else if (patternSwap == 2)
            {
                enemy1.SetActive(false);
                enemy2.SetActive(true);
                enemy3.SetActive(false);
            }
            else if (patternSwap == 3)
            {
                enemy1.SetActive(false);
                enemy2.SetActive(false);
                enemy3.SetActive(true);

            }
     }
            // Start is called before the first frame update
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemySwap();
        PickUp();

    }
}
