using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwordPhysics : MonoBehaviour
{
    public Transform target;
    public float Force;
    public Slider forceUI;
    public Rigidbody2D rb;
    float rotationSpeed = 500;
    Vector3 currentEulerAngles;
    float x;
    float y;
    float z;
    public bool isDead;
    public GameObject sword;
    Vector3 originalPos;
    Vector3 originalRo;
    public bool shot;
    public UIScriptGameOver gameOver;
    public int scoreValue = 1;
    public SwordCameraShake shake;
    public AudioClip hitSound;
    public AudioSource hitSource;
    public int maxForce;
    public int direction = 1;
    public float time;



    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(sword.transform.position.x, sword.transform.position.y, sword.transform.position.z);
        originalRo = new Vector3(sword.transform.rotation.x, sword.transform.rotation.y, sword.transform.rotation.z);
        rb = GetComponent<Rigidbody2D>();
        shot = false;
      //  gameOver = GameObject.FindObjectOfType<UIScriptGameOver>();
        shake = GameObject.FindObjectOfType<SwordCameraShake>();

    }

    // Update is called once per frame
    void Update()
    {

            if (shot == true)
            {
                    time += Time.deltaTime;
                    if (time >= 5)
                    {
                        killplayer();
                    }
                        
            }
        if (shot == false) 
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (direction > 0)
                {
                    Force++;
                    slider();
                    if (Force >= maxForce)
                    {
                        direction = -1;
                    }
                }
                else
                {
                    Force--;
                    slider();
                    if (Force <= 0)
                    {
                        direction = 1;
                    }
                }
                z = 1 - z;
                
                

                    currentEulerAngles += new Vector3(x, y, z) * Time.deltaTime * rotationSpeed;

                transform.eulerAngles = currentEulerAngles;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {

                shoot();
                shot = true;
               
                gameOver.AddScore(scoreValue);


            }
        }

    }

    private void killplayer()
    {
        
        Debug.Log("killplayer");
        sword.SetActive(false);
        sword.transform.position = originalPos;
        sword.transform.eulerAngles = originalRo;
        shot = false;
        time = 0;
        if (shot == false)
        {
           ResetGauge();

        }
    }

    void shoot()
    {
        rb.AddForce(transform.up * Force);
        


        //GetComponent<Rigidbody2D>().AddForce(currentEulerAngles * Force, ForceMode2D.Impulse);

    }

    public void slider()
    {
        forceUI.value = Force;

    }

    public void ResetGauge()
    {
        Force = 0;
        forceUI.value = 0;
        time = 0;
        Debug.Log("what");
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor")
        {



            sword.SetActive(false);
            sword.transform.position = originalPos;
            sword.transform.eulerAngles = originalRo;
            ResetGauge();
            shot = false;
            Debug.Log("collision");
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        shake.StartShake();
        hitSource.clip = (hitSound);
        hitSource.Play();
        if (other.gameObject.CompareTag ("enemy"))
        {
            //FindObjectOfType<HitStop>().Stop(0.1f);
           
            //AudioSource.PlayClipAtPoint(destroySoundClip, transform.position, 1f);



        }

    }
}
