using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealEnemySpawn : MonoBehaviour
{
    public List<EnemySpawner> Enemies;

    public float gapTimer;
    public int patternSwap;
   
    public float spawnTime;
    public SongManager songManagerScript;
    public float timer;


    private void Awake()
    {
        
        //patternSwap = 1;
        //foreach(GameObject Enemy in Enemies)
        //{
        //    Enemy.SetActive(false);
        //}


    }

    void EnemySwap()
    {
        gapTimer += Time.deltaTime;

        if (gapTimer >= spawnTime)
        {
            gapTimer = 0;
            patternSwap = Random.Range(0, Enemies.Count);
            PickUp();
        }

    }

    void PickUp()
    {
        Enemies[patternSwap].EnemyShoot();
        //for(int i = 0; i<Enemies.Count; i++)
        //{
        //    bool isOn = i == patternSwap;
        //    Enemies[i].SetActive(isOn);
        //}

        //if (patternSwap == 1)
        //{
        //    enemy1.SetActive(true);
        //    enemy2.SetActive(false);
        //    enemy3.SetActive(false);

        //}
        //else if (patternSwap == 2)
        //{
        //    enemy1.SetActive(false);
        //    enemy2.SetActive(true);
        //    enemy3.SetActive(false);
        //}
        //else if (patternSwap == 3)
        //{
        //    enemy1.SetActive(false);
        //    enemy2.SetActive(false);
        //    enemy3.SetActive(true);

        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
    }

    void EnemyOn()
    {
        timer += Time.deltaTime;
        //if (timer == 10)
        //{
        //    gameObject.SetActive(true);
        //}

        if (timer >= 60)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EnemyOn();
        EnemySwap();
        //PickUp();

    }
}
