using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camerascript : MonoBehaviour {

    public float panspeed = 30f;
    public float panborderthickness = 10f;
    public GameObject gamepaused;
    public bool pause;

    //public float scrollspeed = 5f;

    public float minx = 0f;
    public float maxx = 40f;

    // Use this for initialization
    void Start () {
        pause = false;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(transform.position.x);
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panborderthickness)
        {
            //Debug.Log("AAA");
            if(transform.position.x >= maxx)
            {
                return;
            }
            transform.Translate(Vector3.right * panspeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= panborderthickness)
        {
            if (transform.position.x <= minx)
            {
                //Debug.Log(transform.position.x);
                return;
            }
            transform.Translate(Vector3.left * panspeed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            soundfx.playsound("pause");
            if (pause == false)
            {
                Time.timeScale = 0;
                pause = true;
                gamepaused.SetActive(true);
            }

            else
            {
                Time.timeScale = 1;
                pause = false;
                gamepaused.SetActive(false);
            }
            //Debug.Log("AAA");
        }
    }
}
