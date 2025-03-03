using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableStringRight : MonoBehaviour
{
    public AttackRight attackRightScript;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    //public void OnClick()
    //{
    //    Debug.Log(gameObject.name + " has been clicked!");
    //}

    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("da real click");
            attackRightScript.clickedStringRight += 1;
        }
    }
}
