using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public float timer=0.5f;
    public Background back;
    public GameObject meteor;
    public float entityTimer = 1f;
    System.Random rand = new System.Random();
    public GameObject enemy;
    public int mode;
    public float gameTimer=2f;
    public bool isPlay = true;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
        gameTimer += Time.deltaTime;
        if (timer <= -1f) timer = 0.1f;
         timer -= Time.deltaTime;

        if (transform.position.y < -4f)
        {
            transform.position = new Vector3(transform.position.x, -4f, 0);
        }
        if (transform.position.y > 4f)
        {
            transform.position = new Vector3(transform.position.x, 4f, 0);
        }
        if (transform.position.x < -8f)
        {
            transform.position = new Vector3(-8f,transform.position.y , 0);
        }
        if (transform.position.x > 8f)
        {
            transform.position = new Vector3(8f, transform.position.y, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0,speed * Time.deltaTime , 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0,-speed * Time.deltaTime , 0);
        }
        if (Input.GetKey(KeyCode.Space)&&timer<=0)
        {
            Shot();
            /*GameObject bull= Instantiate(bullet);
            bull.transform.position = transform.position+ new Vector3(0,1,0);
            timer = 0.5f;*/
        }
        entityTimer -= Time.deltaTime;
        if (entityTimer <= 0)
        {
            SpawnEntity();
            if (gameTimer <= 10f)
            {
                entityTimer = 2f;
            }
            else if (gameTimer <= 15f)
            {
                entityTimer = 1f;
            }else if (gameTimer <= 20f)
            {
                entityTimer = 0.5f;
            }
            //entityTimer = rand.Next(1, 5);
        }

        }
    }
    public void SpawnEntity()
    {
        int entity = rand.Next(0,2);
        if (entity == 0)
        {
        GameObject met = Instantiate(meteor);
        met.transform.position = new Vector3(rand.Next(-7,9),7,0);
        met.GetComponent<Metror>().metSpeed = rand.Next(1, 10);
        met.transform.eulerAngles = new Vector3(0, 0, rand.Next(-31, 31));
    }
        if (entity == 1)
        {
            GameObject eni = Instantiate(enemy);
            eni.transform.position = new Vector3(rand.Next(-7, 9), 7, 0);
            eni.GetComponent<Metror>().metSpeed = rand.Next(1, 10);
            int mode = rand.Next(0, 2);
            if(mode==0)
            {
                eni.GetComponent<Ebemy>().isAlpha = true;
            }
            if (mode == 1)
            {
                eni.GetComponent<Ebemy>().isAlpha = false;
            }
        }

    }
    public void Shot()
    {
        if (mode == 0)
        {
            GameObject bull = Instantiate(bullet);
            bull.transform.position = transform.position + new Vector3(0, 1f, 0);
            timer = 0.2f;
        }
        if (mode == 1)
        {
            GameObject bull = Instantiate(bullet);
            bull.transform.position = transform.position + new Vector3(-0.5f, 1f, 0);
            GameObject bull2 = Instantiate(bullet);
            bull2.transform.position = transform.position + new Vector3(0.5f, 1f, 0);
            timer = 0.2f;
        }
        if (mode >= 2)
        {
            GameObject bull = Instantiate(bullet);
            bull.transform.position = transform.position + new Vector3(-0.5f, 1f, 0);
            GameObject bull2 = Instantiate(bullet);
            bull2.transform.position = transform.position + new Vector3(0.5f, 1f, 0);
            GameObject bull3 = Instantiate(bullet);
            bull3.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            timer = 0.2f;
        }

    }
    public void Stop()
    {
        isPlay = false;
        Bullet b = GetComponent<Bullet>();
        b.bulletSpeed = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor" || collision.gameObject.tag=="EBullet")
        {
            Destroy(gameObject);
            back.pGSpeed = 0;
        }
    }
}
