using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour {

    public level levl;
    public int currentGold;
    public int levelStandard;
    public int levelScout;
    public int levelSniper;
    public int levelTank;
    public int playerLevel;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        currentGold = PlayerPrefs.GetInt("Uang");
        levelStandard = PlayerPrefs.GetInt("standard");
        levelScout = PlayerPrefs.GetInt("scout");
        levelSniper = PlayerPrefs.GetInt("sniper");
        levelTank = PlayerPrefs.GetInt("tank");
        playerLevel = PlayerPrefs.GetInt("level");
    }

    public void GetMoney()
    {
        PlayerPrefs.SetInt("Uang", currentGold + levl.gold);
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("Uang", 0);
        PlayerPrefs.SetInt("standard", 0);
        PlayerPrefs.SetInt("scout", 0);
        PlayerPrefs.SetInt("sniper", 0);
        PlayerPrefs.SetInt("tank", 0);
        PlayerPrefs.SetInt("level", 1);
    }
}
