using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pasukan : MonoBehaviour {

    public Sprite ultForm;


    public bool ismoving = false;
    public bool dir;
    public bool mUltimate = false;
    public bool kUltimate = false;
    public bool bUltimate = false;
    public bool pUltimate = false;
    public bool ult = false;
    public bool doneCheck = false;
    public bool turret = false;

    public int respawntime = 5;

    public float health = 100;
    public float healthPerang;
    public int initspeed = 3;
    public int initSpeedPerang;
    public int speed;
    public float range = 5f;
    public int population;
    public int maxpop;

    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    public Transform targettomove;
    public Transform targettoback;

    private float scale;
    private Transform target;
    public string enemyTag = "Enemy";
    private GameObject enemy;

    public Transform firePoint;

    public WaveSpawner waveSpawner;
    public int idPasukan;

    public int jenisPasukan;

    public Movement movement;

    public Save save;

    //public int special;
    //public bool specialtrigger;

    // Use this for initialization
    void Start()
    {
        //specialtrigger = false;
        save = FindObjectOfType<Save>();
        movement = FindObjectOfType<Movement>();
        scale = transform.localScale.x;
        waveSpawner = FindObjectOfType<WaveSpawner>();
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        /*if(special == 3)
        {
            if(specialtrigger)
            {
                health = health + 100000;
            }
        }*/

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
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

    void Update()
    {
        if (!doneCheck)
        {
            CheckUnit();
            doneCheck = true;
        }
        
        if (mUltimate && !ult)
        {
            ult = true;
            healthPerang = healthPerang + 200;
            mUltimate = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ultForm;
        }

        if (kUltimate && !ult)
        {
            ult = true;
            range = range + 10;
            kUltimate = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ultForm;
        }

        if (pUltimate && !ult)
        {
            ult = true;
            range = range + 3;
            fireRate = fireRate + 3;
            pUltimate = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ultForm;
        }

        if (target != null && dir)
        {
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
            speed = 0;
            return;
        }

        if (bUltimate && !ult)
        {
            ult = true;
            healthPerang = healthPerang + 1000;
            bUltimate = false;
            turret = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = ultForm;
        }

        if (!ismoving || turret)
        {
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            return;
        }

        if (dir)
        {
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
            if (Vector2.Distance(transform.position, targettomove.position) <= 0.2f)
            {
                speed = 0;
                return;
            }

            speed = initspeed;

            Vector2 dir = targettomove.position - transform.position;
            transform.Translate(dir.normalized.x * speed * Time.deltaTime, 0, 0);
        }
        if(!dir)
        {
            transform.localScale = new Vector3(-scale, transform.localScale.y, transform.localScale.z);
            if (Vector2.Distance(transform.position, targettoback.position) <= 0.2f)
            {
                speed = 0;
                return;
            }

            speed = initspeed;

            Vector2 dir = targettoback.position - transform.position;
            transform.Translate(dir.normalized.x * speed * Time.deltaTime, 0, 0);
        }
        

        
    }

    void Shoot()
    {
        //Debug.Log("SHOOT!");
        soundfx.playsound("laser");
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position,firePoint.localRotation);
        //bulletGo.transform.rotation = bulletPrefab.transform.rotation;
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.seek(target);
        }
    }

    public void maju()
    {
        ismoving = !ismoving;
    }

    public void TakeDamage(float amount)
    {
        healthPerang -= amount;
        if (healthPerang <= 0)
        {
            die();
        }
    }

    void die()
    {
        soundfx.playsound("destroy");
        waveSpawner.RecalculatePop(idPasukan);
        movement.merah.Remove(this);
        movement.biru.Remove(this);
        movement.putih.Remove(this);
        movement.kuning.Remove(this);
        Destroy(gameObject);
    }

    public void CheckUnit()
    {
        if(jenisPasukan == 0)
        {
            healthPerang = health + (save.levelStandard * 50);
        }
        if (jenisPasukan == 1)
        {
            healthPerang = health + (save.levelScout * 50);
        }
        if (jenisPasukan == 2)
        {
            healthPerang = health + (save.levelSniper * 50);
        }
        if (jenisPasukan == 3)
        {
            healthPerang = health + (save.levelTank * 150);
        }
    }
}

