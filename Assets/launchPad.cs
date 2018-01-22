using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchPad : MonoBehaviour {
    AudioSource soundFx;
    // Use this for initialization
    void Start () {
        soundFx = GetComponent<AudioSource>();
        soundFx.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
