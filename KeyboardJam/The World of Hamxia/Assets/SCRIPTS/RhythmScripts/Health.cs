using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthBar;
    // public GameManagerScript gameManager;
    public float damage;
    public Animator animator;
    public SongManager songManager;
    public int hurt;
    public Mana manaScript;
    public AttackOne attackScript;

    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        damage = 20;
        hurt = 20;
    }

    // Update is called once per frame
    void Update()
    {
       

        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);

        if (health <= 0)
        {
            Debug.Log("dead");
            //isDead = true;
            //gameManager.gameOver();
            //Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //take damage
        if (other.gameObject.CompareTag("enemy"))

        {

            songManager.currentScore -= hurt;
            animator.Play("Hit");
            manaScript.mana = 0;
            attackScript.clickedString = 0;
            //StartCoroutine(shake.Shaking());
            // AudioSource.PlayClipAtPoint(damageSoundClip, transform.position, 1f);
            //onHitedDec = true;

        }
        //else if (collision.gameObject.GetComponent<MediumAsteroid>() != null)
        //{

        //    health -= 25;
        //    //StartCoroutine(shake.Shaking());
        //    //AudioSource.PlayClipAtPoint(damageSoundClip, transform.position, 1f);
        //    //onHitedDec = true;


        //}
        //else
        //{
        //    //  onHitedDec = false;
        //}

    }
}
