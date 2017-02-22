using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerAlpha : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Start_Level()
    {
        Application.LoadLevel(1);
    }

    public void ExitLevel()
    {
        Application.LoadLevel(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
