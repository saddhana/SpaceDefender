using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 5f;

    public string tag;

    public int damage = 50;
    public int damagePerang;

    public Save save;

    public Rigidbody2D rigid;

    public int jenis;

    public void seek(Transform _target)
    {
        target = _target;
    }

	// Use this for initialization
	void Start () {
        save = FindObjectOfType<Save>();
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckPesawat();
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        //transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        //transform.LookAt(target);
        if(tag == "Enemy")
        {
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        }
        if (tag == "Player")
        {
            rigid.velocity = new Vector2(-speed, rigid.velocity.y);
        }

        //rigid.angularVelocity = rotationSpeed;
    }

    void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
    }

    void Damage(Transform enemy)
    {
        if(tag == "Enemy")
        {
            Enemy e = enemy.GetComponent<Enemy>();
            if (e != null)
            {
                e.TakeDamage(damagePerang);
            }
        }
        
        if(tag == "Player")
        {
            pasukan e = enemy.GetComponent<pasukan>();
            if (e != null)
            {
                e.TakeDamage(damagePerang);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D musuh)
    {
        if(musuh.tag == tag)
        {
            HitTarget();
        }
        if(musuh.tag == "Base")
        {
            basehealth e = musuh.GetComponent<basehealth>();
            if(e.tanda == "Player" && tag == "Player")
            {
                e.TakeDamage(damage);
                Destroy(gameObject);
            }
            else if(e.tanda == "Enemy" && tag == "Enemy")
            {
                e.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }

    public void CheckPesawat()
    {
        if (jenis == 0)
        {
            damagePerang = damage + (save.levelStandard * 15);
        }
        if (jenis == 1)
        {
            damagePerang = damage + (save.levelScout * 10);
        }
        if (jenis == 2)
        {
            damagePerang = damage + (save.levelSniper * 90);
        }
        if (jenis == 3)
        {
            damagePerang = damage + (save.levelTank * 15);
        }
        if (jenis == 4)
        {
            damagePerang = damage;
        }
    }
}
