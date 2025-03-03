using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public int position = 1;
    private float timer;
    public bool ishit;
    int deathPosition = 0;
    public score scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        ishit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            position++;
            position = Mathf.Clamp(position, 1, 7);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            position--;
            position = Mathf.Clamp(position, 1, 7);
        }

        else if (position == 7)
        {
            
           // position = Mathf.Clamp(position, 7, 7);
            timer += Time.deltaTime;
            if (timer > 1.0001)
            {
                position = 1;
                scoreScript.realScore += 5;
            }
            
            
        }
        else if (position == 1)
        {
            timer = 0;
        }
        else if (deathPosition > 0)
        {
          //  position = 1;
        }
            animator.SetInteger("Position", position);
        animator.SetFloat("Time", timer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        deathPosition++;
        animator.SetInteger("DeathPosition", deathPosition);
        Debug.Log("do i work");
        //ishit = true;
        //animator.SetBool("hit", ishit);
    }
}
