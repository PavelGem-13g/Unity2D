using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,speed*Time.deltaTime);
        if (transform.position.y > 15f)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int score = PlayerPrefs.GetInt("score");
        if (collision.gameObject.tag == "Evil")
        {
            score += 5;
            PlayerPrefs.SetInt("score", score);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
