using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullect : MonoBehaviour {

    public AudioClip hitonbarrer;

    public float movespeed = 10;
    public bool isPlayerBullect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * movespeed * Time.deltaTime, Space.World);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Heart":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayerBullect)
                {
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case "Barrier":
                AudioSource.PlayClipAtPoint(hitonbarrer, transform.position);
                Destroy(gameObject);
                break;
            case "Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            default:
                break; 
        }
    }
}
