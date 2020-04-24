using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public Player player;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject die;
    // Start is called before the first frame update
    void Start()
    {
        
        one.SetActive(true);
        two.SetActive(true);
        three.SetActive(true);
        die.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hp == 3)
        {
            one.SetActive(true);
            two.SetActive(true);
            three.SetActive(true);
        }
        if (player.hp == 2)
        {
            one.SetActive(true);
            two.SetActive(true);
            three.SetActive(false);
        }
        if (player.hp == 1)
        {
            one.SetActive(true);
            two.SetActive(false);
            three.SetActive(false);
        }
        if (player.hp <= 0)
        {
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            die.SetActive(true);
        }

    }
}
