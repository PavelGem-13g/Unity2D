using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BulletIndicator : MonoBehaviour
{
    // Start is called before the first frame update
    public BulletSpawner bsp;
    public TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bsp.bulletCount > 0)
        {
            text.text = "" + bsp.bulletCount;
        }
        else
        {
            text.text = "Reloading";
        }
    }
}
