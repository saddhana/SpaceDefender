using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public Save save;
    public GameObject panel;

    // Use this for initialization
    void Start () {
        save = FindObjectOfType<Save>();
    }
	
	// Update is called once per frame
	void Update () {

	}
    

    public void Restart()
    {
        soundfx.playsound("select");
        SceneManager.LoadScene("Level " + level.currentlevel);
    }

    public void Quit()
    {
        soundfx.playsound("select");
        Application.Quit();
    }
    
    public void LevelSelect()
    {
        soundfx.playsound("select");
        SceneManager.LoadScene("LevelSelect");
    }

    public void Back()
    {
        soundfx.playsound("select");
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel(string lepel)
    {
        soundfx.playsound("select");
        SceneManager.LoadScene("Level " + lepel);
    }

    public void ResetData()
    {
        soundfx.playsound("select");
        panel.SetActive(true);
    }
    
    public void No()
    {
        soundfx.playsound("select");
        panel.SetActive(false);
    }

    public void Yes()
    {
        soundfx.playsound("select");
        save.NewGame();
        panel.SetActive(false);
    }

    public void Shop()
    {
        soundfx.playsound("select");
        SceneManager.LoadScene("CharaUp");
    }
}
