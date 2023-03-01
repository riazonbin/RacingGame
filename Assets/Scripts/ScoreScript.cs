using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    int score = 0;

    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text highestScoreText;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IncreaseScore());
        highestScoreText.text = PlayerPrefs.GetInt("HighestScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator IncreaseScore()
    {
        score += 1;
        scoreText.text = score.ToString();

        if(score > PlayerPrefs.GetInt("HighestScore"))
        {
            PlayerPrefs.SetInt("HighestScore", score);
            highestScoreText.text = PlayerPrefs.GetInt("HighestScore").ToString();
        }

        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(IncreaseScore());
    }
}
