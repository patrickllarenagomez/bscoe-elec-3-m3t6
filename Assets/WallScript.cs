using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallScript : MonoBehaviour
{
    GameObject targetPad;
    GameObject rocketShip;
    private Vector3 position = new Vector3(-0.01140663f, -0.01200116f, 5.329071e-15f);
    TargetPadGoal targetPadGoal;
    
    // Use this for initialization
    void Start ()
    {
        targetPad = GameObject.Find("Target Pad");
        rocketShip = GameObject.Find("Rocket Ship");
        targetPadGoal = new TargetPadGoal();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Rocket Ship")
        {
            SceneManager.LoadScene(1);
        }

    }

    void OnCollisionExit(Collision collision)
    {
        transformTargetToColorWhite();
    }

    void transformTargetToColorWhite()
    {
        targetPad.GetComponent<Renderer>().material.color = Color.white;
    }
}
