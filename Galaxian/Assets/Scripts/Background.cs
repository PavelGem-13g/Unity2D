using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float pGSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, pGSpeed * Time.deltaTime,0);
        if (transform.position.y <= -190)
        {
            transform.position = new Vector3(0, 190, 0);
        }
    }
}
