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
    public bool locked;
    public bool otherlock;
    public doorspawn doorScript;

    // Start is called before the first frame update
    void Start()
    {
        ishit = false;
        locked = false;
        otherlock = false;

    }

    // Update is called once per frame
    void Update()
    {
        position = Mathf.Clamp(position, 1, 7);
        if (Input.GetKeyDown(KeyCode.RightArrow) && otherlock == false)
        {
            position++;
            position = Mathf.Clamp(position, 1, 7);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && locked == false)
        {
            position--;
            position = Mathf.Clamp(position, 1, 7);
        }
        else if (position == 2)
        {
            locked = true;
            timer = 0;
        }
        else if (position == 3)
        {
            locked = false;
        }


        else if (position == 7)
        {
            locked = true;
            otherlock = true;
            // position = Mathf.Clamp(position, 7, 7);
            timer += Time.deltaTime;
            if (timer > 0.5)
            {
                position = 1;
                scoreScript.realScore += 5;
                timer = 0;
            }


        }

        else if (position == 6)
        {
            if (doorScript.open == false)
            {
                otherlock = true;
            }
            if (doorScript.open == true)
            {
                otherlock = false;
            }
        }
        else if (position == 5)
        {
            otherlock = false;
        }
        else if (position == 1)
        {
            //otherlock = false;
            timer += Time.deltaTime;
            if (timer >1)
            {
                otherlock = false;
            }
            if (timer > 8)
            {
                position++;
                timer = 0;
            }
            //timer = 0;
            //if (timer == 0)
            //{
            //    timer += Time.deltaTime;
            //    {
            //        if (timer > 4)
            //        {
            //            position++;
            //        }
            //    }
            //}

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
