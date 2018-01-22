using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class ObstacleScript : MonoBehaviour
{
    Rigidbody _rigidBody1;
    BoxCollider boxcollider;
    GameObject targetPad;
    GameObject rocketShip;
    TargetPadGoal targetPadGoal;

    // Use this for initialization
    void Start ()
    {
        _rigidBody1 = GetComponent<Rigidbody>();
        targetPad = GameObject.Find("Target Pad");
        rocketShip = GameObject.Find("Rocket Ship");
       
    }

    // Update is called once per frame
    void Update ()
    {
        Move();
    }

    void Move()
    {
        if(_rigidBody1.position.y > 10)
        {
            _rigidBody1.AddRelativeForce(-Vector3.up);
        }
        else
        {
            _rigidBody1.AddRelativeForce(Vector3.up);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Rocket Ship")
        {
            SceneManager.LoadScene(1);
        }
    }

}
