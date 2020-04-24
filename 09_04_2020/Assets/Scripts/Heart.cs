using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    PlayerContr player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerContr>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            player.HpUp();
        }
    }
}
