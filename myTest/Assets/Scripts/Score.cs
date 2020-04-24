using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    int score;
    int scoreNow;
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
        scoreNow = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score " + scoreNow;
    }
    public void ScoreUP()
    {
        score = PlayerPrefs.GetInt("Score");
        score += 10;
        PlayerPrefs.SetInt("Score", score);
    }
}
