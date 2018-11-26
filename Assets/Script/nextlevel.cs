using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour {

    public int nextlev;

	// Use this for initialization
	void Start () {
        nextlev = level.currentlevel + 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void next()
    {
        soundfx.playsound("select");
        SceneManager.LoadScene("Level " + nextlev);
        //scene
    }

    public void mainmenu()
    {
        soundfx.playsound("select");
        SceneManager.LoadScene("MainMenu");
        //scene
    }

    public void restart()
    {
        soundfx.playsound("select");
        SceneManager.LoadScene("Level " + level.currentlevel);
    }
}
