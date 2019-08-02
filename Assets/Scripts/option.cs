using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class option : MonoBehaviour {


    public Transform pos1;
    public Transform pos2;

    private int choice = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            choice = 1;
            transform.position = pos1.position;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            choice = 2;
            transform.position = pos2.position;
        }
        if (Input.GetKeyDown(KeyCode.Space) && choice == 1)
        {
            SceneManager.LoadScene(0);
        }
	}
}
