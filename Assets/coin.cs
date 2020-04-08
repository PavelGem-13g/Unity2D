using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    score sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<score>();
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
            sc = FindObjectOfType<score>();
            sc.ScoreUp();
        }
    }
}
