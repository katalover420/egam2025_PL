using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leucismove : MonoBehaviour
{
    Vector3 direction = Vector3.left;
    public float speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
