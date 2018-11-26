using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour {

    public Save save;
    public GameObject[] unlockLevel;

    // Use this for initialization
    void Start () {
        save = FindObjectOfType<Save>();
    }
	
	// Update is called once per frame
	void Update () {
        LevelUnlock();
    }

    public void LevelUnlock()
    {
        
        for (int i = 0; i < save.playerLevel; i++)
        {
            unlockLevel[i].SetActive(true);
        }
    }
}
