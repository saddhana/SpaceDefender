using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckStats : MonoBehaviour {

    public pasukan[] army;
    public Bullet[] bullet;
    public Text[] hp;
    public Text[] dmg;
    public Text[] lvl;
    public GameObject standardUI, scoutUI, tankUI, sniperUI;
    public GameObject standardUIUp, scoutUIUp, tankUIUp, sniperUIUp;
    
    public Text[] hargaUI;



    public Save save;

    // Use this for initialization
    void Start () {
        save = FindObjectOfType<Save>();
    }
	
	// Update is called once per frame
	void Update () {
        check();
    }

    public void check()
    {
        hp[0].text = (army[0].health + (save.levelStandard * 50)).ToString();
        dmg[0].text = (bullet[0].damage + (save.levelStandard * 15)).ToString();
        lvl[0].text = (save.levelStandard + 1).ToString();
        if (save.levelStandard == 9)
        {
            standardUI.SetActive(false);
            standardUIUp.SetActive(false);
        }


        hp[1].text = (army[1].health + (save.levelScout * 50)).ToString();
        dmg[1].text = (bullet[1].damage + (save.levelScout * 10)).ToString();
        lvl[1].text = (save.levelScout + 1).ToString();
        if (save.levelScout == 9)
        {
            scoutUI.SetActive(false);
            scoutUIUp.SetActive(false);
        }

        hp[2].text = (army[2].health + (save.levelSniper * 50)).ToString();
        dmg[2].text = (bullet[2].damage + (save.levelSniper * 100)).ToString();
        lvl[2].text = (save.levelSniper + 1).ToString();
        if (save.levelSniper == 9)
        {
            sniperUI.SetActive(false);
            sniperUIUp.SetActive(false);
        }

        hp[3].text = (army[3].health + (save.levelTank * 150)).ToString();
        dmg[3].text = (bullet[3].damage + (save.levelTank * 15)).ToString();
        lvl[3].text = (save.levelTank + 1).ToString();
        if (save.levelTank == 9)
        {
            tankUI.SetActive(false);
            tankUIUp.SetActive(false);
        }



        hargaUI[0].text = "Cost: " + (50 * ((save.levelStandard + 1) * 2)).ToString();
        hargaUI[1].text = "Cost: " + (100 * ((save.levelScout + 1) * 2)).ToString();
        hargaUI[2].text = "Cost: " + (150 * ((save.levelSniper + 1) * 2)).ToString();
        hargaUI[3].text = "Cost: " + (200 * ((save.levelTank + 1) * 2)).ToString();
    }
}
