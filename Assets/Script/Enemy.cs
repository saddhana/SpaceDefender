using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float health = 100;

    public int initspeed = 3;
    public int speed;
    public float range = 5f;
    //public int pops = 1;
    public static int population = 5;

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    public Transform targettomove;


    private Transform target;
    public string enemyTag = "Player";
    private GameObject player;

    public Transform firePoint;

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
        population++;
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        //Debug.Log(pops);
        //Debug.Log(population);
        //population = pops;
        //Debug.Log(population);
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
            speed = 0;
            return;
        }

        if (Vector2.Distance(transform.position, targettomove.position) <= 0.2f)
        {
            speed = 0;
            return;
        }

        speed = initspeed;

        Vector2 dir = targettomove.position - transform.position;
        transform.Translate(dir.normalized.x * speed * Time.deltaTime, 0, 0);
    }

    void UpdateTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject player in players)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = player;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    void Shoot()
    {
        //Debug.Log("SHOOT!");
        soundfx.playsound("laser");
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.localRotation);
        //bulletGo.transform.rotation = bulletPrefab.transform.rotation;
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.seek(target);
        }
    }

}
