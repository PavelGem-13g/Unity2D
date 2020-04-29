using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public int zombieCount;
    public int localZombieCount;
    public float spawnTimer;
    public float localSpawnTimer;
    public GameObject zombie_easy;


    void Start()
    {
        localSpawnTimer = spawnTimer;
        localZombieCount = zombieCount;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer<=0 && zombieCount>0)
        {
            GameObject zom = Instantiate(zombie_easy);
            zom.transform.position = transform.position;
            zombieCount--;
            spawnTimer = localSpawnTimer;
        }
    }
}
