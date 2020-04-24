using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class water : MonoBehaviour
{
    PlayerCont player;
    Color cl;
    Tilemap tMap;
    bool isActive;
    float alpha = 1f;
    // Start is called before the first frame update
    void Start()
    {
        tMap = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive == true)
        {
            if (alpha > 0.5f)
            {
                alpha -= Time.deltaTime;
            }
        }
        if (isActive == false)
        {
            if (alpha < 1f)
            {
                alpha += Time.deltaTime;
            }
        }
        cl = new Color(1f, 1f, 1f, alpha);
        tMap.color = cl;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            player = collision.gameObject.GetComponent<PlayerCont>();
            player.inWater = true;
            player.rb.mass = 2f;
            player.rb.gravityScale = 2f;
            player.speed = 100;
            cl = new Color(1f, 1f, 1f, 0.5f);
            tMap.color = cl;
            isActive = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject.GetComponent<PlayerCont>();
            player.inWater = false;
            player.rb.mass = 1f;
            player.rb.gravityScale = 5f;
            player.speed = 200;
            cl = new Color(1f, 1f, 1f, 1f);
            tMap.color = cl;
            isActive = false;
        }
    }
}
