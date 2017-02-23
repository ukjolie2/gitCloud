using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Movement>().isStopped)
        {
            GetComponent<AudioSource>().mute = true;
        }
	}
}
