using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public pasukan[] army;
    public Text[] jumlah;
    public Image[] respawnbar;

    public float[] time;

    public int[] flag;
    public int[] maxpop;
    public float[] ratio;

    public Transform SpawnPoint;
    public Transform Unit;

    public float countdown = 5;
    public float cooldown = 5;

    public Movement movement;
    private void Start()
    {
        movement = FindObjectOfType<Movement>();
        flag = new int[army.Length];
        maxpop = new int[army.Length];
        time = new float[army.Length];
        ratio = new float[army.Length];
    }

    // Update is called once per frame
    void Update() {
        //army[1].population;
        jumlah[0].text = maxpop[0].ToString() + "/" + army[0].population;
        jumlah[1].text = maxpop[1].ToString() + "/" + army[1].population;
        jumlah[2].text = maxpop[2].ToString() + "/" + army[2].population;
        jumlah[3].text = maxpop[3].ToString() + "/" + army[3].population;

        ratio[0] = (time[0] % army[0].respawntime) / army[0].respawntime;
        respawnbar[0].rectTransform.localScale = new Vector3(ratio[0], 1, 1);
        ratio[1] = (time[1] % army[1].respawntime) / army[1].respawntime;
        respawnbar[1].rectTransform.localScale = new Vector3(ratio[1], 1, 1);
        ratio[2] = (time[2] % army[2].respawntime) / army[2].respawntime;
        respawnbar[2].rectTransform.localScale = new Vector3(ratio[2], 1, 1);
        ratio[3] = (time[3] % army[3].respawntime) / army[3].respawntime;
        respawnbar[3].rectTransform.localScale = new Vector3(ratio[3], 1, 1);

        if (maxpop[0] < army[0].population)
        {
            time[0] += Time.deltaTime;
        }

        if (maxpop[1] < army[1].population)
        {
            time[1] += Time.deltaTime;
        }

        if (maxpop[2] < army[2].population)
        {
            time[2] += Time.deltaTime;
        }

        if (maxpop[3] < army[3].population)
        {
            time[3] += Time.deltaTime;
        }


        if (time[0] > 1)
        {
            anu(time[0], 0);
        }
        if (time[1] > 1)
        {
            anu(time[1], 1);
        }
        if (time[2] > 1)
        {
            anu(time[2], 2);
        }
        if (time[3] > 1)
        {
            anu(time[3], 3);
        }

    }

    void anu(float time, int i)
    {
        if ((time % army[i].respawntime) - 1 <= 0.00000001f)
        {
            if (flag[i] == 0 && maxpop[i] < army[i].population)
            {
                //Debug.Log(i);
                flag[i] = 1;
                StartCoroutine(SpawnWave(i));
                maxpop[i]++;
                //time += army[i].respawntime;
            }

        }

        else
        {
            flag[i] = 0;
        }

    }

    IEnumerator SpawnWave(int i)
    {
        SpawnEnemy(i);
        yield return new WaitForSeconds(0.5f);
    }

    void SpawnEnemy(int i)
    {
       pasukan go = Instantiate(army[i], SpawnPoint.position, SpawnPoint.rotation) as pasukan;
        if (i == 0)
            movement.merah.Add(go);
        if (i == 1)
            movement.putih.Add(go);
        if (i == 2)
            movement.kuning.Add(go);
        if (i == 3)
            movement.biru.Add(go);
    }

    public void RecalculatePop(int i)
    {
        maxpop[i]--;
    }
}
