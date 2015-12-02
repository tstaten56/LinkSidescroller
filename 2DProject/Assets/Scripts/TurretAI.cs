using UnityEngine;
using System.Collections;

public class TurretAI : MonoBehaviour {

    //Integers
    public int curHealth;
    public int maxHealth;

    //Float
    public float distance; //btwn player and turret
    public float wakeRange;
    public float shootInterval;
    public float bulletSpd = 100;
    public float bulletTimer;

    //Boolean
    public bool awake = false;
    public bool lookingRight = true;

    //References
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        curHealth = maxHealth;


    }

    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingRight", lookingRight);

        RangeCheck(); 

        if(target.transform.position.x > transform.position.x)
        {
            lookingRight = true;
        }

        if(target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }

        if(curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position); //get dist btwn turret and player

        //wakeup when player is in awake range
        if(distance < wakeRange)
        {
            awake = true;
        }
        //Go to sleep when player out of awake range
        if (distance > wakeRange)
        {
            awake = false;
        }
    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;

        if(bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();

            if(!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpd;

                bulletTimer = 0;
            }

            if(attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpd;

                bulletTimer = 0;
            }
            
        }
    }

    public void Damage(int dmg)
    {
        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("RedFlash");
    }

}
