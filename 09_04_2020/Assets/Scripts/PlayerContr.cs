using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContr : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource au;
    public int speed;
    public float jumForce;
    public int jumpCount = 2;
    public int hp = 3;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        au = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && hp > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.A) && hp > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0 && hp > 0)
        {
            rb.AddForce(new Vector2(0, jumForce * speed), ForceMode2D.Impulse);
            jumpCount--;
        }
        if (transform.position.y < -30f)
        {
            transform.position = Vector3.zero;
            hp--;
        }

    }
    public void HpUp()
    {
        if (hp < 3) hp++;
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
        if (collision.gameObject.tag == "Frog")
        {
            hp--;

        }
    }
    public void Coin()
    {
        au.Play();
    }
}
