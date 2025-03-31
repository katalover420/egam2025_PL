using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableStringLeft : MonoBehaviour
{
    public SpriteRenderer myRenderer;

    public Color defaultColor;
    public Color hoverColor;
    public AttackSpawnTwo attackLeftScript;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

  

    public void OnClick()
    {
        Debug.Log(gameObject.name + " has been clicked!");
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("da real click");
            attackLeftScript.clickedStringLeft += 1;
        }
    }
}
