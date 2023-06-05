using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer3 : MonoBehaviour
{
    public float timeRemaining = 60;
    private float timeRemainingTemp = 60;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI finalScore;
    public GameObject TeddyBear;

    public void Start()
    {
        TeddyBear.gameObject.SetActive(false);
    }
    
    void Update()
    {
        if (PongScore.score > 0)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeText.text = "Your time is up!";
                if (PongScore.score >= 5)
                {
                    TeddyBear.gameObject.SetActive(true);
                }
                finalScore.text = "Final Score: " + PongScore.score.ToString();
                PongScore.score = 0;
                timeRemaining = timeRemainingTemp;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


