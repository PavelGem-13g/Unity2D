using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject bullet;
    public GameObject power;
    public GameObject evilPlane;
    public Timer timer;
    public int hp;
    public float spawnTime = 2f;
    public float hard;
    System.Random rand = new System.Random();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hp > 0)
        {
            spawnTime -= Time.deltaTime;
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += new Vector3(0, speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= new Vector3(0, speed * Time.deltaTime);
            }
            if (transform.position.y < -3.5)
            {
                transform.position = new Vector3(transform.position.x, -3.5f);
            }
            if (transform.position.y > 3.5)
            {
                transform.position = new Vector3(transform.position.x, 3.5f);
            }
            if (transform.position.x < -8)
            {
                transform.position = new Vector3(-8, transform.position.y);
            }
            if (transform.position.x > 8)
            {
                transform.position = new Vector3(8, transform.position.y);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shot();
            }
            if (spawnTime <= 0)
            {
                Spawn();
                spawnTime = 2f;
            }
        }

    }
    void Shot()
    {
        GameObject bul = Instantiate(bullet);
        bul.transform.position = transform.position + new Vector3(0, 2f);

    }
    void Spawn()
    {
        int entity = rand.Next(0, 2);
        if (entity == 0)
        {
            GameObject pow = Instantiate(power);
            pow.transform.position = new Vector3(rand.Next(-7, 9), 7, 0);
            pow.GetComponent<Evil>().speed = rand.Next(1, 10);
            pow.transform.eulerAngles = new Vector3(0, 0, rand.Next(-31, 31));
        }
        if (entity == 1)
        {
            GameObject pow = Instantiate(evilPlane);
            pow.transform.position = new Vector3(rand.Next(-7, 9), 7, 0); int mode = rand.Next(0, 2);
            pow.GetComponent<EvilPlane>().isAlpha = true;


        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Evil")
        {
            hp--;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "SuperEvil")
        {
            hp = 0;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
