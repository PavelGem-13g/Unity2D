using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed;
    public float localSpeed;
    public float dmgTimer = 0.2f;
    public bool isDamage = false;
    public Player player;
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        localSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        ZCalculate();
        transform.position += transform.up * speed * Time.deltaTime;
        if (isDamage)
        {
            dmgTimer -= Time.deltaTime;
            if (dmgTimer <= 0)
            {
                isDamage = false;
                dmgTimer = 2f;
            }
        }
        else speed = localSpeed;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void ZCalculate()
    {
        Vector2 playerPos = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector2 zombiePos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 resultVector = playerPos - zombiePos;
        float angle = Vector2.SignedAngle(Vector2.up, resultVector);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
    public void TakeDamage()
    {
        speed = 0;
        isDamage = true;
        hp--;
    }

}
