using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metror : MonoBehaviour
{
    public float metSpeed=20;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position -= new Vector3(0, metSpeed * Time.deltaTime, 0);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * metSpeed * Time.deltaTime;
        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
