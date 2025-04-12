using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalDrag : MonoBehaviour
{
    bool MoveRestricted = false;
    private Vector3 screenPoint;
    private Vector3 offset;
    public GameObject curtain;

    private void Start()
    {
        curtain = GameObject.Find("Trans");
    }

    private void Update()
    {
        
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        //curPosition.y = 0;
        transform.position = curPosition;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hi");

        if (other.gameObject.CompareTag("win"))
        {
            Debug.Log("Win!");
            wingame();
        }
    }

    void wingame()
    {

        curtain.GetComponent<Curtain>().gamesWon++;
        StartCoroutine(curtain.GetComponent<Curtain>().CurtainLowerRoutine());
        //Destroy(GameObject.FindWithTag("win"));




    }
}
