using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class basehealth : MonoBehaviour {

    public static bool gameended;
    public GameObject gameoverui;
    public float health = 100;
    public string status;
    public Save save;
    public level leveL;
    public string tanda;

    // Use this for initialization
    void Start () {
        save = FindObjectOfType<Save>();
        leveL = FindObjectOfType<level>();
        gameended = false;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            die();
        }
    }

    void die()
    {
        soundfx.playsound("destroy");
        Destroy(gameObject);
        EndGame();
    }

    void EndGame()
    {
        if(status == "win")
        {
            if(save.playerLevel < leveL.lvl + 1)
            {
                PlayerPrefs.SetInt("level", leveL.lvl + 1);
            }

            Debug.Log("menang");
            save.GetMoney();
        }
        soundfx.playsound(status);
        gameended = true;
        gameoverui.SetActive(true);
    }
}
