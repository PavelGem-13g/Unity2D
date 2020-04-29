using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public int bulletCount;
    public int localBulletCount;
    public float reloadTimer = 1.5f;
    public float shootTimer;
    public float localShootTimer;
    Player player;
    void Start()
    {
        shootTimer= localShootTimer ;
        player = GetComponentInParent<Player>();
        localBulletCount = bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer<=-1)
        {
            shootTimer = 0f;
        }
        if (Input.GetMouseButton(0) && shootTimer <= 0 && bulletCount>0)
        {
            GameObject bul = Instantiate(bullet);
            bul.transform.eulerAngles = player.transform.eulerAngles;
            bul.transform.position = transform.position;
            shootTimer = localShootTimer;
            bulletCount--;
        }
        if (bulletCount <= 0)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                bulletCount = localBulletCount;
                reloadTimer = 1.5f;
            }
        }
    }
}
