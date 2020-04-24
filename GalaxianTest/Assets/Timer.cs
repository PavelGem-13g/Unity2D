using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float time;
    public int sec;
    public int min;
    public float realTime;
    TextMeshProUGUI timeOut;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        timeOut = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        realTime += Mathf.RoundToInt(Time.deltaTime);
        sec = Mathf.RoundToInt(time);
        if (sec >= 60)
        {
            min += 1;
            sec = 0;
            time = 0;
        }
        timeOut.text = min + ":" + sec; 
    }
}
