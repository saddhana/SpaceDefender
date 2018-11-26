using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour {

    public GameObject standardUI, scoutUI, tankUI, sniperUI, menuUI, notEnoughUI;
    public Save save;
    public CheckStats checking;

    // Use this for initialization
    void Start () {
		save = FindObjectOfType<Save>();
        checking = FindObjectOfType<CheckStats>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void StandardUI()
    {
        soundfx.playsound("click");
        Debug.Log("standard");
        menuUI.SetActive(false);
        standardUI.SetActive(true);
    }

    public void ScoutUI()
    {
        soundfx.playsound("click");
        menuUI.SetActive(false);
        scoutUI.SetActive(true);
    }

    public void SniperUI()
    {
        soundfx.playsound("click");
        menuUI.SetActive(false);
        sniperUI.SetActive(true);
    }

    public void TankUI()
    {
        soundfx.playsound("click");
        menuUI.SetActive(false);
        tankUI.SetActive(true);
    }

    public void BackUI()
    {
        soundfx.playsound("select");
        menuUI.SetActive(true);
        notEnoughUI.SetActive(false);
        tankUI.SetActive(false);
        sniperUI.SetActive(false);
        scoutUI.SetActive(false);
        standardUI.SetActive(false);
    }

    public void Upgrade(int id)
    {
        soundfx.playsound("up");
        if (id == 0)
        {
            if(save.currentGold < (50 * ((save.levelStandard + 1) * 2)))
            {
                notEnoughUI.SetActive(true);
                return;
            }
            PlayerPrefs.SetInt("Uang", save.currentGold - (50 * ((save.levelStandard + 1) * 2)));
            PlayerPrefs.SetInt("standard", save.levelStandard + 1);
            checking.check();
        }
        if (id == 1)
        {
            if (save.currentGold < (100 * ((save.levelScout + 1) * 2)))
            {
                notEnoughUI.SetActive(true);
                return;
            }
            PlayerPrefs.SetInt("Uang", save.currentGold - (100 * ((save.levelScout + 1) * 2)));
            PlayerPrefs.SetInt("scout", save.levelScout + 1);
            checking.check();
        }
        if (id == 2)
        {
            if (save.currentGold < (150 * ((save.levelSniper + 1) * 2)))
            {
                notEnoughUI.SetActive(true);
                return;
            }
            PlayerPrefs.SetInt("Uang", save.currentGold - (150 * ((save.levelSniper + 1) * 2)));
            PlayerPrefs.SetInt("sniper", save.levelSniper + 1);
            checking.check();
        }
        if (id == 3)
        {
            if (save.currentGold < (200 * ((save.levelTank + 1) * 2)))
            {
                notEnoughUI.SetActive(true);
                return;
            }
            PlayerPrefs.SetInt("Uang", save.currentGold - (200 * ((save.levelTank + 1) * 2)));
            PlayerPrefs.SetInt("tank", save.levelTank + 1);
            checking.check();
        }
    }
}
