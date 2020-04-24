using UnityEngine;
using System;
public class Ebemy : MonoBehaviour
{
    public float speed;
    public float speed_y;
    public float shootTime = 1f;
    public float movementTimer;
    public GameObject bullet;
    public bool isAlpha = false;
    public bool isForword = true;
    public GameObject sB;
    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isAlpha == false)
        {
            transform.position += new Vector3(0, -speed * Time.deltaTime, 0);
        }
        else if (isAlpha == true)
        {
            transform.position += new Vector3(speed * Time.deltaTime, -speed_y * Time.deltaTime, 0);

            if (isForword == true)
                speed_y += Time.deltaTime;

            if (isForword == false)
                speed_y -= Time.deltaTime;

            if (speed_y >= 2f)
            {
                isForword = false;
            }
            if (speed_y <= -2f)
            {
                isForword = true;
            }
            if (transform.position.x >= 15f || transform.position.y<=-15f)
            {
                Destroy(gameObject);
            }
        }
        shootTime -= Time.deltaTime;
        if (shootTime <= 0)
        {
            GameObject b = Instantiate(bullet);
            b.transform.position = transform.position + new Vector3(0, -1.4f, 0);
            shootTime = 1f;
        }
    }
    public void Death()
    {
        int chance = rnd.Next(0,3);
        if (chance == 0)
        {
        GameObject sb = Instantiate(sB);
        sb.transform.position = transform.position;
        Destroy(gameObject);
        }
    }
}
