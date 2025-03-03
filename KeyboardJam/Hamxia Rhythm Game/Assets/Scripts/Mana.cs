using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mana : MonoBehaviour
{
    public Image manaCircle;
    public float mana;
    public float maxMana;
    public float fill;
    public AttackOne attackScript;
    public SongManager songScript;
    // Start is called before the first frame update
    void Start()
    {
        maxMana = 60;
        //fill = attackScript.clickedString;
    }

    // Update is called once per frame
    void Update()
    {
        manaCircle.fillAmount = Mathf.Clamp(mana / maxMana, 0, 1);

        if (mana == 80)
        {
            //StartCoroutine(Wait());
            mana = 0;

        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
