using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoyCtrl : MonoBehaviour
{
    [SerializeField] Text currScoreText;
    [SerializeField] Text highestScoreText;

    int currScore = 0;
    int highestScore = 0;


    private void Start()
    {
        if(PlayerPrefs.HasKey("Highest Score"))
        {
            highestScore = PlayerPrefs.GetInt("Highest Score");
            highestScoreText.text = "最高紀錄：" + highestScore;
                }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Score")
        {
            currScore += 25;

            currScoreText.text = "目前分數：" + currScore;

            if(currScore > highestScore)
            {
                highestScore = currScore;
                highestScoreText.text = "最高紀錄：" + highestScore;
            }


            Destroy(other.gameObject);
        }
    }
    void SaveScore() 
    {
        PlayerPrefs.SetInt("Highest Score", highestScore);
    }
}
