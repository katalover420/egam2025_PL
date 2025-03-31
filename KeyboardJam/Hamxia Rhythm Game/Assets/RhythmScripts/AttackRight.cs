using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRight : MonoBehaviour
{
    // Start is called before the first frame update
    public Bullet bulletScript;
    public GameObject bulletPrefab;

    public int clickedStringRight;
    public ClickableStringRight clickStringScript;
    // Start is called before the first frame update
    void Start()
    {
        clickedStringRight = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (clickedStringRight == 3)
        {
            Debug.Log("ATTACK!");
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.ShootBullet(-transform.up);

            clickedStringRight = 0;

        }


    }
}
