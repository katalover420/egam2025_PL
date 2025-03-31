using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickableString : MonoBehaviour
{
    public SpriteRenderer myRenderer;

    public Color defaultColor;
    public Color hoverColor;
    public Color clickColor;
    public AttackOne attackScript;
    float clickTimer;
    public float clickDuration;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clickTimer >0 )
        {
            clickTimer -= Time.deltaTime;
        }
    }

    public void Reset()
    {
        if (clickTimer <= 0)
        {
            myRenderer.color = defaultColor;
        }
        
    }

    public void OnHover()
    {
        if (clickTimer <= 0)
        {
            myRenderer.color = hoverColor;
        }
        
    }

    public void OnClick()
    {
        myRenderer.color = clickColor;
        clickTimer = clickDuration;
        Debug.Log(gameObject.name + " has been clicked!");
        
    }

    //public void OnMouseOver()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("da real click");
    //        myRenderer.color = clickColor;
    //        attackScript.clickedString += 1;
    //    }
  //  }


}
