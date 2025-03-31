using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScript : MonoBehaviour
{
    public GameManagerScript gameManagerScript;
    public int enemyLeft;
    public CameraShake shake;
    public bool isHit;
    
    [SerializeField] private AudioClip destroySoundClip;
    
    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        shake = GameObject.FindObjectOfType<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    


    void OnTriggerEnter2D(Collider2D other)
    {
        
        {
            FindObjectOfType<HitStop>().Stop(0.3f);
            //AudioSource.PlayClipAtPoint(destroySoundClip, transform.position, 1f);
            Destroy(this.gameObject);
            isHit = false;


        }

    }
}
