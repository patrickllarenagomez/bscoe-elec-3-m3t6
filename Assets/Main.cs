using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    // Use this for initialization

    public int stageLevel;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(stageLevel == 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                stageLevel = 1;
                SceneManager.LoadScene(1);
            }
        }
 
    }
}
