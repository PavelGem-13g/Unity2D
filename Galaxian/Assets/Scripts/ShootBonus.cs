using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBonus : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0,Time.deltaTime*speed,0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerCont>().mode += 1;
            Destroy(gameObject);
        }
    }
}
