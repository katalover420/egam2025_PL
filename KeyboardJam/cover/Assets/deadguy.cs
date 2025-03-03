using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadguy : MonoBehaviour
{
    public Animator animator;
    public float timer;
    int deathPosition = 0;
    int position = 0;
    public Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >2)
        {
            deathPosition = 0;
           playerScript.position = 1;
            animator.SetInteger("DeathPosition", deathPosition);
           // animator.SetInteger("Position", position);
            timer = timer - 2;
        }
    }
}
