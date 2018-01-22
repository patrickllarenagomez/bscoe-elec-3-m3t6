using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondRocket : MonoBehaviour
{

    // Use this for initialization
    [SerializeField] float thrust1 = 250f;
    [SerializeField] float rcsthrust1 = 100f;
    Rigidbody _rigidBody1;
    private bool isBumped = false;
    GameObject rocketShip1;
    bool _isSoundPlaying1;
    private Vector3 position1 = new Vector3(-4.47f, 3.57f, 0f);
    private Quaternion rotation1 = new Quaternion(0f, 0f, 0f, 0f);
    private float waitingTime = .2f;
    AudioSource _audioSource1;
    GameObject targetPad;

    void Start()
    {
        _rigidBody1 = GetComponent<Rigidbody>();
        _audioSource1 = GetComponent<AudioSource>();
        _isSoundPlaying1 = false;
        targetPad = GameObject.Find("Target Pad");
    }

    // Update is called once per frame
    void Update()
    {
        Fly1();
    }

    void Fly1()
    {

        float rotationSpeed = rcsthrust1 * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _rigidBody1.AddRelativeForce(Vector3.up * thrust1 * Time.deltaTime);
            if (!_isSoundPlaying1)
            {
                _audioSource1.Play();
                _isSoundPlaying1 = true;
            }

            else
            {
                _audioSource1.Stop();
                _isSoundPlaying1 = false;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
    }

    void RestartRocketPositionAndRotation1()
    {
        transform.position = position1;
        _rigidBody1.angularVelocity = new Vector3(0f, 0f, 0f);
        _rigidBody1.velocity = new Vector3(0f, 0f, 0f);
        transform.rotation = Quaternion.identity;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            RestartRocketPositionAndRotation1();
        }

        if (collision.gameObject.name == "Second Rocket Ship")
        {
            changeTargetPadColorToGreen();
        }

    }

    void changeTargetPadColorToGreen()
    {
        targetPad.GetComponent<Renderer>().material.color = Color.green;
    }

}
