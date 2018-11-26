using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{

    public static bool gameloss;
    public GameObject gamelossui;
    public float health = 100;

    // Use this for initialization
    void Start()
    {
        gameloss = false;
    }

    // Update is called once per frame
    void Update()
    {

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
        gameloss = true;
        gamelossui.SetActive(true);
    }
}
