using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer2 : MonoBehaviour
{
    public float timeRemaining = 60;
    private float timeRemainingTemp = 60;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI finalScore;
    public GameObject gift;
    

    void Start()
    {
        gift.gameObject.SetActive(false);
    }

    void Update()
    {
        if (ShootingTowerScore.score > 0)
        {

            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeText.text = "Your time is up!";
                if (ShootingTowerScore.score >= 50)
                {
                    gift.gameObject.SetActive(true);
                }
                finalScore.text = "Final Score: " + ShootingTowerScore.score.ToString();
                ShootingTowerScore.score = 0;
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

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer1 : MonoBehaviour
{
    public float timeRemaining = 10;
    public TextMeshProUGUI timeText;
    public bool timerIsRunning;
    public bool timerIsRunning2;

    void Start()
    {
        timerIsRunning2 = false;
        timerIsRunning = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if(timerIsRunning == false)
                timerIsRunning2 = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            if (timerIsRunning == true)
                timerIsRunning2 = false;
        }
    }
    void Update()
    {
        if(timerIsRunning == false && timerIsRunning2 == true)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }

            else
            {
                timerIsRunning2 = false;
                timeText.text = "Your time is up! ";
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}*/
