using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hp > 0)
        {
            text.text = "" + player.hp;
        }
        else text.text = "";


    }
}
