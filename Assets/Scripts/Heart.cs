using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour {


    private SpriteRenderer sr;
    public Sprite brokenSprite;
    public AudioClip dieaudio;


   public GameObject explosionprefabs;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        //
        sr.sprite = brokenSprite;
        Instantiate(explosionprefabs, transform.position, transform.rotation);
        Playermanager.Instance.isDefeat = true;
        AudioSource.PlayClipAtPoint(dieaudio, transform.position);
    }
}
