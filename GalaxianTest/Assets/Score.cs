using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    int score;
    int scoreNow;
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreNow = PlayerPrefs.GetInt("score");
        text.text = "score " + scoreNow;
    }
    public void ScoreUp(int up)
    {
        score = PlayerPrefs.GetInt("score");
        score += up;
        PlayerPrefs.SetInt("Score", score);
    }
}
