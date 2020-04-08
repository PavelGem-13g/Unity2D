using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject first;
    public GameObject second;
    public GameObject third;
     PlayerCont player;
    void Start()
    {
        player = FindObjectOfType<PlayerCont>();
        
    }

    // Update is called once per frame
    void Update()
    {
    if (player.health == 3)
    {
        third.SetActive(true);
        second.SetActive(false);
        first.SetActive(false);
    }
    if (player.health == 2)
    {
        second.SetActive(true);
        first.SetActive(false);
        third.SetActive(false);
    }
    if (player.health == 1)
    {
        first.SetActive(true);
        second.SetActive(false);
        third.SetActive(false); 
        }
        if (player.health <= 0)
        {
            first.SetActive(false);
            second.SetActive(false);
            third.SetActive(false);
        }
    }
}



        
