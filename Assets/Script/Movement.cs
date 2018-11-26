using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject[] selected;
    public GameObject[] ultimate;
    public Image[] ultBar;
    public GameObject[] ultiBar;
    public float[] ratio;
    public float[] time;
    public int[] flag;
    public Save save;

    public List<pasukan> merah;
    public List<pasukan> kuning;
    public List<pasukan> biru;
    public List<pasukan> putih;

    public int fmerah;
    public int fkuning;
    public int fbiru;
    public int fputih;

    public int tipe;
    // Use this for initialization
    void Start () {
        fmerah = 0;
        fkuning = 0;
        fbiru = 0;
        fputih = 0;
        tipe = 4;
        save = FindObjectOfType<Save>();
    }
	
	// Update is called once per frame
	void Update () {
        move();
        CheckLevel();
        if (save.levelStandard == 9 && time[0] <= 30)
        {
            time[0] += Time.deltaTime;
        }

        if (save.levelScout == 9 && time[1] <= 30)
        {
            time[1] += Time.deltaTime;
        }

        if (save.levelSniper == 9 && time[2] <= 60)
        {
            time[2] += Time.deltaTime;
        }

        if (save.levelTank == 9 && time[3] <= 60)
        {
            time[3] += Time.deltaTime;
        }

        ratio[0] = time[0] / 30;
        ultBar[0].rectTransform.localScale = new Vector3(ratio[0], 1, 1);
        ratio[1] = time[1] / 30;
        ultBar[1].rectTransform.localScale = new Vector3(ratio[1], 1, 1);
        ratio[2] = time[2] / 60;
        ultBar[2].rectTransform.localScale = new Vector3(ratio[2], 1, 1);
        ratio[3] = time[3] / 60;
        ultBar[3].rectTransform.localScale = new Vector3(ratio[3], 1, 1);

        CheckTime();
    }

    public void CheckLevel()
    {
        if (save.levelStandard == 9)
        {
            ultiBar[0].SetActive(true);
        }

        if (save.levelScout == 9)
        {
            ultiBar[1].SetActive(true);
        }

        if (save.levelSniper == 9)
        {
            ultiBar[2].SetActive(true);
        }

        if (save.levelTank == 9)
        {
            ultiBar[3].SetActive(true);
        }
    }

    public void goforward()
    {
        soundfx.playsound("click");
        if (tipe == 0)
        {
            fmerah = 1;
        }

        if (tipe == 1)
        {
            fputih = 1;
        }

        if (tipe == 2)
        {
            fkuning = 1;
        }

        if (tipe == 3)
        {
            fbiru = 1;
        }
        //pasukan.ismoving = true;
        //pasukan.dir = true;
    }

    public void stop()
    {
        soundfx.playsound("click");
        if (tipe == 0)
        {
            fmerah = 0;
        }

        if (tipe == 1)
        {
            fputih = 0;
        }

        if (tipe == 2)
        {
            fkuning = 0;
        }

        if (tipe == 3)
        {
            fbiru = 0;
        }
        //pasukan.ismoving = false;
    }

    public void goback()
    {
        soundfx.playsound("click");
        if (tipe == 0)
        {
            fmerah = 2;
        }

        if (tipe == 1)
        {
            fputih = 2;
        }

        if (tipe == 2)
        {
            fkuning = 2;
        }

        if (tipe == 3)
        {
            fbiru = 2;
        }
        //pasukan.ismoving = true;
        //pasukan.dir = false;
    }

    public void Merah()
    {
        soundfx.playsound("click");
        selected[0].SetActive(true);
        selected[1].SetActive(false);
        selected[2].SetActive(false);
        selected[3].SetActive(false);
        Debug.Log("0");
        tipe = 0;
    }

    public void Putih()
    {
        soundfx.playsound("click");
        selected[0].SetActive(false);
        selected[1].SetActive(true);
        selected[2].SetActive(false);
        selected[3].SetActive(false);
        Debug.Log("1");
        tipe = 1;
    }

    public void Kuning()
    {
        soundfx.playsound("click");
        selected[0].SetActive(false);
        selected[1].SetActive(false);
        selected[2].SetActive(true);
        selected[3].SetActive(false);
        Debug.Log("2");
        tipe = 2;
    }

    public void Biru()
    {
        soundfx.playsound("click");
        selected[0].SetActive(false);
        selected[1].SetActive(false);
        selected[2].SetActive(false);
        selected[3].SetActive(true);
        Debug.Log("3");
        tipe = 3;
    }

    public void UltimateMerah()
    {
        soundfx.playsound("click");
        for (int i = 0; i < merah.Count; i++)
        {
            merah[i].mUltimate = true;
            ultimate[0].SetActive(false);
            ultiBar[0].SetActive(true);
            time[0] = 0;
        }
    }

    public void UltimateKuning()
    {
        soundfx.playsound("click");
        for (int i = 0; i < kuning.Count; i++)
        {
            kuning[i].kUltimate = true;
            ultimate[2].SetActive(false);
            ultiBar[2].SetActive(true);
            time[2] = 0;
        }
    }

    public void UltimateBiru()
    {
        soundfx.playsound("click");
        for (int i = 0; i < biru.Count; i++)
        {
            biru[i].bUltimate = true;
            ultimate[3].SetActive(false);
            ultiBar[3].SetActive(true);
            time[3] = 0;
        }
    }

    public void UltimatePutih()
    {
        soundfx.playsound("click");
        for (int i = 0; i < putih.Count; i++)
        {
            putih[i].pUltimate = true;
            ultimate[1].SetActive(false);
            ultiBar[1].SetActive(true);
            time[1] = 0;
        }
    }

    public void move()
    {
        //MERAH
        if(fmerah == 0)
        {
            for (int i = 0; i < merah.Count; i++)
            {
                merah[i].ismoving = false;
            }
        }
        else if (fmerah == 1)
        {
            for (int i = 0; i < merah.Count; i++)
            {
                merah[i].ismoving = true;
                merah[i].dir = true;
            }
        }
        else if (fmerah == 2)
        {
            for (int i = 0; i < merah.Count; i++)
            {
                merah[i].ismoving = true;
                merah[i].dir = false;
            }
        }
        //KUNING
        if (fkuning == 0)
        {
            for (int i = 0; i < kuning.Count; i++)
            {
                kuning[i].ismoving = false;
            }
        }
        else if (fkuning == 1)
        {
            for (int i = 0; i < kuning.Count; i++)
            {
                kuning[i].ismoving = true;
                kuning[i].dir = true;
            }
        }
        else if (fkuning == 2)
        {
            for (int i = 0; i < kuning.Count; i++)
            {
                kuning[i].ismoving = true;
                kuning[i].dir = false;
            }
        }
        //PUTIH
        if (fputih == 0)
        {
            for (int i = 0; i < putih.Count; i++)
            {
                putih[i].ismoving = false;
            }
        }
        else if (fputih == 1)
        {
            for (int i = 0; i < putih.Count; i++)
            {
                putih[i].ismoving = true;
                putih[i].dir = true;
            }
        }
        else if (fputih == 2)
        {
            for (int i = 0; i < putih.Count; i++)
            {
                putih[i].ismoving = true;
                putih[i].dir = false;
            }
        }
        if (fbiru == 0)
        {
            for (int i = 0; i < biru.Count; i++)
            {
                biru[i].ismoving = false;
            }
        }
        else if (fbiru == 1)
        {
            for (int i = 0; i < biru.Count; i++)
            {
                biru[i].ismoving = true;
                biru[i].dir = true;
            }
        }
        else if (fbiru == 2)
        {
            for (int i = 0; i < biru.Count; i++)
            {
                biru[i].ismoving = true;
                biru[i].dir = false;
            }
        }
    }

    public void CheckTime()
    {
        if(time[0] >= 30)
        {
            //soundfx.playsound("ultimate");
            ultimate[0].SetActive(true);
            ultiBar[0].SetActive(false);
        }
        if (time[1] >= 30)
        {
            //soundfx.playsound("ultimate");
            ultimate[1].SetActive(true);
            ultiBar[1].SetActive(false);
        }
        if (time[2] >= 60)
        {
            //soundfx.playsound("ultimate");
            ultimate[2].SetActive(true);
            ultiBar[2].SetActive(false);
        }
        if (time[3] >= 60)
        {
            //soundfx.playsound("ultimate");
            ultimate[3].SetActive(true);
            ultiBar[3].SetActive(false);
        }
    }
}
