using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundfx : MonoBehaviour {

    public static AudioClip laser, destroy, baseboom, win, lose, click, ultimate, pause, select, up;
    static AudioSource audiosrc;

	// Use this for initialization
	void Start () {
        laser = Resources.Load<AudioClip>("Laser_09");
        destroy = Resources.Load<AudioClip>("Laser_01");
        baseboom = Resources.Load<AudioClip>("Laser_03");
        win = Resources.Load<AudioClip>("Jingle_Win_01");
        lose = Resources.Load<AudioClip>("Jingle_Lose_00");
        click = Resources.Load<AudioClip>("Click");
        ultimate = Resources.Load<AudioClip>("Ultimate");
        pause = Resources.Load<AudioClip>("Menu_Select_00");
        select = Resources.Load<AudioClip>("Menu_Select_01");
        up = Resources.Load<AudioClip>("up");
        audiosrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void playsound (string clip)
    {
        switch (clip)
        {
            case "laser":
                audiosrc.PlayOneShot(laser);
                break;
            case "destroy":
                audiosrc.PlayOneShot(destroy);
                break;
            case "baseboom":
                audiosrc.PlayOneShot(baseboom);
                break;
            case "win":
                audiosrc.PlayOneShot(win);
                break;
            case "lose":
                audiosrc.PlayOneShot(lose);
                break;
            case "click":
                audiosrc.PlayOneShot(click);
                break;
            case "ultimate":
                audiosrc.PlayOneShot(ultimate);
                break;
            case "pause":
                audiosrc.PlayOneShot(pause);
                break;
            case "select":
                audiosrc.PlayOneShot(select);
                break;
            case "up":
                audiosrc.PlayOneShot(up);
                break;
        }
    }
}
