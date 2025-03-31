using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 500f;



    public Rigidbody2D enemyRigidbody;
    // Start is called before the first frame update

    void Awake()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShootEnemy(Vector2 direction)
    {
        //Add a force to the bullet
        enemyRigidbody.AddForce(direction * speed);
        //Destroy the bullet after it reaches its max lifetime


    }

    void OnTriggerEnter2D(Collider2D other)
    {

        {
            
            Destroy(this.gameObject);
            


        }

    }
}
