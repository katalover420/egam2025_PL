using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOne : MonoBehaviour
{
    public Bullet bulletScript;
    public GameObject bulletPrefab;

    public int clickedString;
    public ClickableString clickStringScript;
    public NoteObject noteScript;
    // Start is called before the first frame update
    void Start()
    {
        clickedString = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (clickedString == 4)
        {
            Debug.Log("ATTACK!");
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.ShootBullet(-transform.up);

            clickedString = 0;


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
