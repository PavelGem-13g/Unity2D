using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public Zombie zombie;
    public SpriteRenderer sp;
    void Start()
    {
        zombie = GetComponentInParent<Zombie>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(0.1f*zombie.hp,0.2f,1);
        if (zombie.hp > 5)
        {
            sp.color = Color.green;
        }
        else if (zombie.hp > 2)
        {
            sp.color = Color.yellow;
        }
        else
        {
            sp.color = Color.red;
        }
    }
}
