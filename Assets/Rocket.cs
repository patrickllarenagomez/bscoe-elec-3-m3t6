using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Rocket : MonoBehaviour {

    // Use this for initialization
    [SerializeField] float thrust = 150f;
    [SerializeField] float rcsthrust = 100f;
    Rigidbody _rigidBody;
    private bool isBumped = false;
    GameObject rocketShip;
    bool _isSoundPlaying;
    private Vector3 position = new Vector3(0.0002282565f, 1.758f, 5.551115e-16f);
    private Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
    AudioSource _audioSource;
    GameObject targetPad;
    BoxCollider boxCollider;
    ParticleSystem particleSys;
    TargetPadGoal targetPadGoal;

    //GameObject[] obstacles;
    BoxCollider[] boxColliders;
    void Start () {
        _rigidBody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _isSoundPlaying = false;
        targetPad = GameObject.Find("Target Pad");
        boxCollider = GetComponent<BoxCollider>();
        particleSys = GetComponent<ParticleSystem>();
        targetPadGoal = new TargetPadGoal();
        
    }

    // Update is called once per frame
    void Update ()
    {
        Fly();
	}

    void Fly()
    {
        float rotationSpeed = rcsthrust * Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {

            _rigidBody.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if (!_isSoundPlaying && Input.GetKeyDown(KeyCode.Space))
            {
                _audioSource.Play();
                _isSoundPlaying = true;
                particleSys.Emit(100);
                var emission = particleSys.emission;
                emission.enabled = true;
                particleSys.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _audioSource.Pause();
            _isSoundPlaying = false;
            particleSys.Stop();
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.O))
        {
            var temp = GameObject.FindGameObjectsWithTag("Obstacle");
            boxColliders = new BoxCollider[temp.Length];

            for (int i = 0; i < boxColliders.Length; i++)
            {
                boxColliders[i] = temp[i].GetComponent<BoxCollider>();
                boxColliders[i].enabled = false;
            }
        }
    }
    void RestartRocketPositionAndRotation()
    {
        transform.position = position;  
        _rigidBody.angularVelocity = new Vector3(0f, 0f, 0f);
        _rigidBody.velocity = new Vector3(0f, 0f, 0f);
        transform.rotation = Quaternion.identity;
    }

    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag == "Obstacle") 
            {
                RestartRocketPositionAndRotation();
            }

        if (collision.gameObject.name == "Target Pad")
        {
            targetPadGoal.bumpedByRocket = true;
            changeTargetPadColorToGreen();
        }
    }

    void changeTargetPadColorToGreen()
    {
        targetPad.GetComponent<Renderer>().material.color = Color.green;
    }

}
