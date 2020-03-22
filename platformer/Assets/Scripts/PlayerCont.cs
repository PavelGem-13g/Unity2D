using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public int health;
    bool isDead = false;
    public int jumpCount;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) 
        {
            rb.AddForce(new Vector2(speed*Time.deltaTime,rb.velocity.y));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, rb.velocity.y));
        }
        if (Input.GetKeyDown(KeyCode.Space)&& jumpCount>0) 
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector2(0, speed *jumpForce),ForceMode2D.Impulse);
            jumpCount--;
        }
        Debug.Log(rb.velocity);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCount = 2;
        }
        if (collision.gameObject.tag == "DieLine") 
        {
            transform.position=new Vector3(0,0,0);   
        }
    }

}
