using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Image currentHP;
    public basehealth hp;
    public float maxhp;

	// Use this for initialization
	void Start () {
        maxhp = hp.health;
	}
	
	// Update is called once per frame
	void Update () {
        float ratio = hp.health / maxhp;
        if(hp.health < 0)
        {
            ratio = 0;
        }
        currentHP.rectTransform.localScale = new Vector3(ratio, 1, 1);
	}
}
