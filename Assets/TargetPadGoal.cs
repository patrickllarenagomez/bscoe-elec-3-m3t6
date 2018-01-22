using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetPadGoal : MonoBehaviour {

    GameObject targetPad;
    GameObject RocketShip;
    [SerializeField] float preferredDistance = 20f;
    private float distanceRocket;
    private float FirstRocketDistance;
    public bool bumpedByRocket = false;
    // Use this for initialization
    void Start ()
    {
		targetPad = GameObject.Find("Target Pad");
        RocketShip = GameObject.Find("Rocket Ship");

    }
	
	// Update is called once per frame
	void Update ()
    {
        FirstRocketDistance = Vector3.Distance(RocketShip.transform.position, targetPad.transform.position);
        if (bumpedByRocket == false)
            checkDistance();
        else
            changeTargetPadColorToGreen();


    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Rocket Ship" && targetPad.gameObject.tag != "LastPad")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }   

        if (collision.gameObject.name == "Rocket Ship" && targetPad.gameObject.tag == "LastPad")
        {
            changeTargetPadColorToGreen();
            bumpedByRocket = true;
        }

    }



    void changeTargetPadColorToGreen()
    {
        targetPad.GetComponent<Renderer>().material.color = Color.green;
    }

    void changeTargetPadColorToBlue()
    {
        targetPad.GetComponent<Renderer>().material.color = Color.blue;
    }

    void changeTargetPadColorToRed()
    {
        targetPad.GetComponent<Renderer>().material.color = Color.red;
    }

    void checkDistance()
    {
        if (FirstRocketDistance < preferredDistance)
        {
            if(targetPad.gameObject.tag == "LastPad")
            {
                changeTargetPadColorToRed();
            }
            else if (targetPad.gameObject.tag == "SecondPad")
            {
                changeTargetPadColorToBlue();
            }
            else
            {
                changeTargetPadColorToGreen();
            }
        }
        else
        {
            changeToOriginalColor();
        }
    }

    void changeToOriginalColor()
    {
        targetPad.GetComponent<Renderer>().material.color = Color.white;
        
    }

}
