
using UnityEngine;
using System.Collections;

public class LinkControllerScript : MonoBehaviour
{

    //Floats
    public float maxSpeed = 3;
    public float speed = 50f;
    public float jumpPower = 150f;

    //Booleans
    public bool grounded;
    public bool canDoubleJump;

    //Stats
    public int curHealth;
    public int maxHealth = 5;

    //References
    private Rigidbody2D rb2d;
    private Animator anim;

    private GameMaster gm;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

        curHealth = maxHealth;
        //Debug.Log(curHealth);
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }


    void Update()
    {


        anim.SetBool("Ground", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(8, 8, 8);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(-8, 8, 8);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rb2d.AddForce(Vector2.up * jumpPower);
                canDoubleJump = true;
            }
            else
            {

                if (canDoubleJump)
                {

                    canDoubleJump = false;
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
                    rb2d.AddForce(Vector2.up * jumpPower / 1.75f);

                }

            }
        }

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }

        if (curHealth <= 0)
        {

            curHealth = 0;

            Die();

        }



    }

    void FixedUpdate()
    {
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.y = rb2d.velocity.y;
        easeVelocity.z = 0.0f;
        easeVelocity.x *= 0.75f;

        float h = Input.GetAxis("Horizontal");

        //Fake friction / Easing the x speed of our player
        if (grounded)
        {

            rb2d.velocity = easeVelocity;

        }


        //Moving the player
        rb2d.AddForce((Vector2.right * speed) * h);

        //Debug.Log(rb2d.velocity);
        //Limiting the speed of the player
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

    }

    void Die()
    {
        if(PlayerPrefs.HasKey("HighRupees"))
        {
            //Is the current score > highRupees?
            if (PlayerPrefs.GetInt("HighRupees") < gm.rupees)
            {
                PlayerPrefs.SetInt("HighRupees", gm.rupees);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighRupees", gm.rupees);
        }
        Application.LoadLevel(Application.loadedLevel);

    }

    public void Damage(int dmg)
    {

        curHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("RedFlash");

    }


    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {
        Debug.Log("Knockback");

        float timer = 0;
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        while (knockDur > timer)
        {

            timer += Time.deltaTime;
            //rb2d.velocity = new Vector2(0, 0);
            rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));

        }

        yield return 0;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("GreenRupee"))
        {
            Destroy(col.gameObject);
            gm.rupees += 1;
        }
        if(col.CompareTag("RedRupee"))
        {
            Destroy(col.gameObject);
            gm.rupees += 20;
        }
        if (col.CompareTag("BlueRupee"))
        {
            Destroy(col.gameObject);
            gm.rupees += 5;
        }
    }

}












//using UnityEngine;
//using System.Collections;

//public class LinkControllerScript : MonoBehaviour {
//    public float maxSpeed = 3;
//    public float speed = 50f;
//    bool facingRight = true;
//    Rigidbody2D rBody;

//    Animator anim;

//    //Character falling
//    public bool grounded = false;
//    public Transform groundCheck;
//    float groundRadius = 0.2f;
//    public LayerMask whatIsGround;

//    public float jumpForce = 1300;

//    bool doubleJump = false;


//    //Player Stats
//    public int currentHealth;
//    public int maxHealth = 100;

//    // Use this for initialization
//	void Start () {
//        rBody = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        currentHealth = maxHealth;
//	}

//	// Update is called once per frame
//	void FixedUpdate ()
//    {
//        //Character is grounded? Is there a collider there or not, True = we are on ground, False=not on ground
//        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
//        anim.SetBool("Ground", grounded);

//        anim.SetFloat("vSpeed", rBody.velocity.y);

//        if (grounded)
//        {
//            doubleJump = false;
//        }
//        else
//        {
//            return;
//        }
//      //  Character movement side to side
//        float move = Input.GetAxis("Horizontal");

//        anim.SetFloat("Speed", Mathf.Abs(move));

//        rBody.velocity = new Vector3(move * maxSpeed, rBody.velocity.y);

//        //Debug.Log(move);
//        if (move < -.012 && !facingRight)
//        {
//            Flip();
//        }
//        else if (move > 0 && facingRight)
//        {
//            Flip();
//        }

//        float h = Input.GetAxis("Horizontal");

//        //Moving the player
//        //rBody.AddForce((Vector3.right * speed) * h);

//        ////Limiting the speed of player
//        //if (rBody.velocity.x > maxSpeed)
//        //{
//        //    rBody.velocity = new Vector2(maxSpeed, rBody.velocity.y);
//        //}

//        //if (rBody.velocity.x < -maxSpeed)
//        //{
//        //    rBody.velocity = new Vector2(-maxSpeed, rBody.velocity.y);
//        //}

//    }

//    void Update()
//    {
//        anim.SetBool("Ground", grounded);
//        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));

//        //if (Input.GetAxis("Horizontal") < -0.1f)
//        //{
//        //    transform.localScale = new Vector3(-1, 1, 1);
//        //}

//        //if (Input.GetAxis("Horizontal") > 0.1f)
//        //{
//        //    transform.localScale = new Vector3(1, 1, 1);
//        //}
//        Debug.Log(transform.position);

//        //Jumping here
//        if ((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
//        { //Shouldn't do this keycoat.space
//            anim.SetBool("Ground", false);
//            rBody.AddForce(new Vector2(0, jumpForce));

//            if (!doubleJump && !grounded)
//            {
//                doubleJump = true;
//            }
//        }

//        //if ((grounded && Input.GetKeyDown(KeyCode.Mouse0)))
//        //{
//        //    attacking = true;
//        //}


//        //Don't let current health be above max health
//        if (currentHealth > maxHealth)
//        {
//            currentHealth = maxHealth;
//        }

//        //Kill player
//        if(currentHealth <= 0)
//        {
//            Die();
//        }


//    }

//    void Flip()
//    {
//        facingRight = !facingRight;
//        Vector3 theScale = transform.localScale;
//        theScale.x *= -1;
//        transform.localScale = theScale;
//    }

//    void Die()
//    {
//        //TODO:Create death screen and death animation
//        //This just reloads the level
//        Application.LoadLevel(Application.loadedLevel);
//    }

//    public void Damage(int dmg)
//    {
//        if (currentHealth < dmg)
//        {
//            dmg = currentHealth;
//        }
//        currentHealth -= dmg;
//    }

//    //Things that take time, runs thru each frame?
//    public IEnumerator Knockback(float knockDur, float knockbackPower, Vector3 knockbackDir)
//    {
//        float timer = 0; //Count the time since we entered the func
//        int dir = 1;
//        while(knockDur > timer)
//        {
//            if (facingRight)
//            {
//                dir *= -1;
//            }

//            timer += Time.deltaTime; //Counts in seconds that has passed
//            //-100 is Opposite way we are heading on the x axis
//            rBody.velocity = new Vector2(0, 0);   //<----------------------
//            rBody.AddForce(new Vector3(knockbackDir.x * (dir*100), knockbackDir.y + knockbackPower, transform.position.z));
//            //rBody.AddForce(new Vector3((dir * 1000), knockbackDir.y + knockbackPower, transform.position.z));

//        }

//        yield return 0; //In IEnumerator you have to return something, this stops the IEnumerator
//    }
//}
