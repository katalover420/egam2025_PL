using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpawnTwo : MonoBehaviour
{
    public Bullet bulletScript;
    public GameObject bulletPrefab;

    public int clickedStringLeft;
    public ClickableStringLeft clickStringScript;
    // Start is called before the first frame update
    void Start()
    {
        clickedStringLeft = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (clickedStringLeft == 3)
        {
            Debug.Log("ATTACK!");
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.ShootBullet(-transform.up);

            clickedStringLeft = 0;

        }


    }

    //void StringMax()
    //{
    //    if (clickStringScript.stringclick == true)
    //    {
    //        clickedString += 1;
    //    }
    //}

}
