using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{
    public float fSecs;
    public int sec;
    public int min;
     TextMeshProUGUI time;
    public PlayerCont player;
    // Start is called before the first frame update
    void Start()
    {
        time = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isPlay && player!=null)
        {
        fSecs += Time.deltaTime;
        }

        sec = Mathf.RoundToInt(fSecs);
        if (sec>=60)
        {
            min += 1;
            sec = 0;
            fSecs = 0;
        }
        if (min < 10)
        {
        if (sec <10 )
        {
            time.text = min + ":" +"0"+ sec;
        }
        if (sec >= 10)
        {
            time.text = min + ":"  + sec;
        }

        }
        else time.text = min + ":" + sec;
        
    }
}
