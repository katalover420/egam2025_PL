using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorspawn : MonoBehaviour
{
    public GameObject door;
    public GameObject dooropen;
    public float time;
    public int patternswap;
    public bool open;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn();
        PickUp();
        animator.SetBool("open", open);
    }
    void PickUp()
    {

        if (patternswap == 0)
        {
            door.SetActive(true);
            dooropen.SetActive(false);
            open = false;
           

        }
        else if (patternswap == 1)
        {
            door.SetActive(false);
            dooropen.SetActive(true);
            open = true;
            
        }
      
    }

    void spawn()
    {
        time += Time.deltaTime;
        if (time > 3)
        {

            patternswap = Random.Range(0, 2);
            time = 0;
        }
    }


}
