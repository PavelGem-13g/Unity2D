using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{
    int Score;
    int ScoreNow;
    TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreNow = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score -" + ScoreNow;
        
    }
    public void ScoreUp() 
    {
        Score = PlayerPrefs.GetInt("Score");
        Score += 10;
        PlayerPrefs.SetInt("Score",Score);
    }
}
