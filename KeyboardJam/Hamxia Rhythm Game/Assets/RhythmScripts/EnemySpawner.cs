using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyScript;
    public GameObject enemyPrefab;
    public bool isShot;
    public float enemyTimer;
    

    void Awake()
    {
        isShot = false;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
    //    enemyTimer += 1 * Time.deltaTime;

    //    if (enemyTimer >= 2 && isShot == false)
    //    {
            
    //        isShot = true;
    //        enemyTimer = 0;
    //        EnemyShoot();
    //    }
    //}

    public void EnemyShoot()
    {
        GameObject enemyInstance = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemyScript = enemyInstance.GetComponent<Enemy>();
        enemyScript.ShootEnemy(transform.up);
        isShot = false;
    }

   
}
