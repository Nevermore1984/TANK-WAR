using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour {


    public GameObject player;
    public GameObject[] enemyprefabs;
    public bool iscreateenenmy;

	// Use this for initialization
	void Start () {
        Invoke("BornTank", 1f);
        Destroy(gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BornTank()
    {
        if (!iscreateenenmy)
        {
            //随机0  1
            int num = Random.Range(0, 2);
            Instantiate(enemyprefabs[num], transform.position, Quaternion.identity);
        }
        else
            Instantiate(player, transform.position, Quaternion.identity);
    }
}
