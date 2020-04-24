using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evil : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up*speed*Time.deltaTime;
        if (transform.position.y < -15f)
        {
            Destroy(gameObject);
        }
    }
   
}
