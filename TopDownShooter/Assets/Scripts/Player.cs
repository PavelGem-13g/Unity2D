using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int hp;
    public float godModeTimer;
    public bool isGodMode = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Calculate();
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime);
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        if (isGodMode)
        {
            godModeTimer -= Time.deltaTime;
            if (godModeTimer<=0)
            {
                isGodMode = false;
                godModeTimer = 0.5f;
            }
        }
    }
    public void Calculate()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 resultVector = mousePos - playerPos;
        float angle = Vector2.SignedAngle(Vector2.up, resultVector);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            hp--;
            isGodMode = true;
        }
    }
}
