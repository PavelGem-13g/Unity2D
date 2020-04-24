using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public float jumpForce;
    public float jumpCout;

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
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCout>0)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector2(0, speed * jumpForce*5), ForceMode2D.Impulse);
            jumpCout--;
        }
        if (gameObject.transform.position.y<-10f)
        {
            gameObject.transform.position = Vector3.zero;
            rb.velocity = Vector2.zero;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCout = 2;
        }
    }
}

    