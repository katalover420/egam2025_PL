using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HingeObject : MonoBehaviour
{
    public HingeJoint2D hinge;
    public float motorSpeed = 200;
    public Animator animator;
    public float time;
    public GameManager managerScript;
    public GameObject winScreen;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        
        string sceneName = currentScene.name;
    }
    void Update()
    {
        // On down - set the motor to positive
        if (Input.GetMouseButtonDown(0))
        {
            // Make a referecne to the motor
            JointMotor2D tempMotor = hinge.motor;

            // Change values on the reference
            tempMotor.motorSpeed = motorSpeed;

            // Then reassign the updated motor
            hinge.motor = tempMotor;
        }
        // On up - set the motor to negative
        else if (Input.GetMouseButtonUp(0))
        {
            // Make a referecne to the motor
            JointMotor2D tempMotor = hinge.motor;

            // Change values on the reference
            tempMotor.motorSpeed = -motorSpeed;

            // Then reassign the updated motor
            hinge.motor = tempMotor;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }


      }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            time += Time.deltaTime;
            animator.SetBool("Touch", true);
            if (time >= 3)
            {
                managerScript.Win();
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level1"))
            {
                if (time >= 5)
                {
                    managerScript.levelTwo();
                }
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level2"))
            {
                if (time >= 5)
                {
                    managerScript.Level3();
                }
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level3"))
            {
                if (time >= 5)
                {
                    managerScript.Level4();
                }
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level4"))
            {
                if (time >= 5)
                {
                    managerScript.Level5();
                }
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level5"))
            {
                if (time >= 5)
                {
                    managerScript.Level6();
                }
            }
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level6"))
            {
                if (time >= 5)
                {
                    winScreen.SetActive(true);
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            time = 0;
            animator.SetBool("Touch", false);
        }
    }
}
