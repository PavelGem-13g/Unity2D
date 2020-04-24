using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
Animator anim;
    public float speed;
    public float jumpForce;
    public int health=3;
    bool isDead = false;
    public int jumpCount;
    public float timer = 3f;
    bool dead = false;
    public bool inWater;
    public int oxygen;
    public Rigidbody2D rb;
    CircleCollider2D cirCol;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cirCol = GetComponent<CircleCollider2D>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
anim.SetBool("isRun",false);
        //timer = Time.deltaTime;
        /*if (timer <= 0)
        {
            timer = 3f;
        }*/
        //if(inWater==TransparencySortMode)
        cirCol = GetComponent<CircleCollider2D>();
        if (inWater == true) 
        {
            oxygen--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //gameObject.transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(new Vector2(speed * Time.deltaTime, rb.velocity.y));
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);

//anim.SetBool("isRun",true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //gameObject.transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(new Vector2(-speed * Time.deltaTime, rb.velocity.y));
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);

//anim.SetBool("isRun",true);

        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector2(0, speed * jumpForce*15), ForceMode2D.Impulse);

anim.SetBool("isRun",true);
            jumpCount--;
        }
        if (gameObject.transform.position.y < -10)
        {
            dead = true;
            /*transform.position = new Vector3(0, 0, 0);
            rb.velocity = Vector3.zero;*/
        }
        if (dead == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && health >= 1)
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector3.zero;
                timer = 2f;
                dead = false;
                health--;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 2;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Spike")
        {
            health--;
            rb.AddForce(new Vector2(-200, 500));
        }
        if (health <= 0) 
        {
            rb.AddForce(new Vector2(0, 1000));
            Destroy(cirCol);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water") 
        {
            oxygen--;
        }
    }
}
