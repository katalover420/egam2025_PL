using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LineForce : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    private bool isIdle;
    private bool isAiming;
    public Rigidbody rigidbody;
    public int strokes = 10;
    [SerializeField]  private float stopVelocity = .05f;
    [SerializeField]  private float shotPower = .05f;
    public TextMeshProUGUI strokeNumber;
    public GameObject loseScreen;
    public GameObject winScreen;
    private Vector3 originalPos;
    public int seedCount;
    public GameObject holeCover;
    public int seedRequirement;
    public Renderer meshRenderer;
    public Material material0;
    public bool speedActive;
    public float speedBoost = 1f;
    public int totalStrokes;
    public TextMeshProUGUI resultStrokes;
    public TextMeshProUGUI flowersCollected;
    public int totalScore;
    public int finalScore;
    public GameObject spawn1;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        meshRenderer.material = material0;
        isAiming = false;
        lineRenderer.enabled = false;

    }
    private void Update()
    {
        if (rigidbody.linearVelocity.magnitude < stopVelocity)
        {
            Stop();
        }
        ProcessAim();

        

        if (seedCount == seedRequirement)
        {
            holeCover.SetActive(false);
            meshRenderer.material.color = Color.green;
        }
    }

    private void OnMouseDown()
    {
        if (isIdle)
        {
            isAiming = true;
        }
    }

    private void Stop()
    {
        rigidbody.linearVelocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        isIdle = true;
    }
    private void ProcessAim()
    {
        if(!isAiming || !isIdle)
        {
            return;
        }
        Vector3? worldPoint = CastMouseClickRay();

        if (!worldPoint.HasValue)
        {
            return;
        }

        DrawLine(worldPoint.Value);

        if(Input.GetMouseButtonUp(0))
        {
            Shoot(worldPoint.Value);
        }
    }

    private void Shoot(Vector3 worldPoint)
    {
        originalPos = transform.position;
        isAiming = false;
        lineRenderer.enabled = false;

        Vector3 horizontalWorldPoint = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);

        Vector3 direction = (horizontalWorldPoint - transform.position).normalized;
        float strength = Vector3.Distance(transform.position, horizontalWorldPoint);

        rigidbody.AddForce(-direction * strength * shotPower);
        isIdle = false;

        strokes++;
        totalStrokes++;

        resultStrokes.text = totalStrokes.ToString();

        strokeNumber.text = strokes.ToString();
    }
    private void DrawLine(Vector3 worldPoint)
    {
        Vector3[] positions =
        {
            transform.position, worldPoint

        };
        lineRenderer.SetPositions(positions);
        lineRenderer.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("win"))
        {
            winScreen.SetActive(true);
        }
        if (other.CompareTag("seed"))
        {
            seedCount += 1;
            flowersCollected.text = seedCount.ToString();
        }
        
    }

    private Vector3? CastMouseClickRay()
    {
        Vector3 screenMousePosFar = new Vector3
            (
            Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3
            (Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        if (Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit, float.PositiveInfinity))
        {
            return hit.point;
        }
        else
        {
            return null;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("bounds"))
        {
            transform.position = originalPos;
            Stop();
        }
    }

    public void HoleTwo()
    {
        //rigidbody.position = spawn1.transform.position;
        //strokes = 0;
        //totalScore = totalStrokes;
        //totalStrokes = 0;
        //seedCount = 0;
        //holeCover.SetActive(true);
        //winScreen.SetActive(false);

    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
}
