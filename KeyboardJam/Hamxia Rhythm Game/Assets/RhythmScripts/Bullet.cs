using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public float speed = 500f;

    public float lifetime = 10f;

    public Rigidbody2D bulletRigidbody;

    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootBullet(Vector2 direction)
    {
        //Add a force to the bullet
        bulletRigidbody.AddForce(direction * speed);
        //Destroy the bullet after it reaches its max lifetime
        Destroy(gameObject, lifetime);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
    //    //Destroy the bullet as soon as it collides with anything
       // Destroy(gameObject);

    //    //Print the name of the gameobject i hit
    //    Debug.Log(collision.gameObject);

    }

}
