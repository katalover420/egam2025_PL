using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    //public ClickableStringRight stringRightScript;
    public GameObject topNote;
    public GameObject middleNote;
    public GameObject bottomNote;
    public AttackOne attackScript;
    public Animator animator;
    public float clickTimer;
   // public SongManager songScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (clickTimer > 0)
        {
            clickTimer -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.Play("Left");
            if (canBePressed)
            {
                animator.SetBool("Fail", false);
                topNote.SetActive(false);
               
              //  attackScript.clickedString += 1;
                SongManager.instance.NoteHit();
               if (animator.GetBool("GoodCombo"))
                {
                    animator.Play("leftsuccess");
                }

            }

        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.Play("Right");
            if (canBePressed)
            {
                animator.SetBool("Fail", false);
                bottomNote.SetActive(false);

              //  attackScript.clickedString += 1;
                SongManager.instance.NoteHit();
                if (animator.GetBool("GoodCombo"))
                {
                    animator.Play("rightsuccess");
                }
            }
        }
        //ClickableString[] allObjects = FindObjectsOfType<ClickableString>();
        //foreach (ClickableString clickable in allObjects)
        //{
        //    clickable.Reset();
        //}

        //Vector2 mousePosition = Input.mousePosition;

        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //Debug.DrawRay(worldPosition, Vector3.one);
        //Collider2D overlappingCollider = Physics2D.OverlapPoint(worldPosition);
        //if (overlappingCollider != null)
        //{
        //    ClickableString clickable = overlappingCollider.transform.GetComponent<ClickableString>();
        //    if (clickable != null)
        //    {
        //       clickable.OnHover();

        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            clickable.OnClick();
        //        }

        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            if (canBePressed && overlappingCollider.transform.name == ("TopString"))
        //            {
        //                clickable.OnClick();
        //                topNote.SetActive(false);
        //                //clickable.Shoot();
        //                attackScript.clickedString += 1;
        //                SongManager.instance.NoteHit();

        //            }

        //        }
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            if (canBePressed && overlappingCollider.transform.name == ("MiddleString"))
        //            {
        //                clickable.OnClick();
        //                middleNote.SetActive(false);
        //                //clickable.Shoot();
        //                attackScript.clickedString += 1;
        //                SongManager.instance.NoteHit();

        //            }

        //        }
        //        if (Input.GetMouseButtonDown(0))
        //        {
        //            if (canBePressed && overlappingCollider.transform.name == ("BottomString"))
        //            {
        //                clickable.OnClick();
        //                bottomNote.SetActive(false);
        //                //clickable.Shoot();
        //                attackScript.clickedString += 1;
        //                SongManager.instance.NoteHit();

        //            }

        //        }
        //    }


        //  }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            SongManager.instance.NoteMissed();
           
        }
    }
}
