using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer1 : MonoBehaviour
{
    public float timeRemaining = 5;
    private float timeRemainingTemp = 5;
    public TextMeshProUGUI timeText;
    public bool timerIsRunning;
    public bool timerIsRunning2;
   

    void Start()
    {
        timerIsRunning = false;
        timerIsRunning2 = true;
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && timerIsRunning2)
        {
            timerIsRunning = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand") )
        {
            timerIsRunning = false;
            timerIsRunning2 = true;
        }
    }

    void Update()
    {
        
        if (timerIsRunning == true) //!timerIsRunning && timerIsRunning2)
        {
            if (timeRemaining >= 0 && timerIsRunning2)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timerIsRunning = false;
                timerIsRunning2 = false;
                timeText.text = "Your time is up! ";
                ShootingTowerScore.score = 0;
                DuckGameScoreKeeper.score = 0;
                return;
            }
        }
        else
        {
            timeRemaining = 5;
            timerIsRunning2 = false;
            ShootingTowerScore.score = 0;
            DuckGameScoreKeeper.score = 0;
            timeText.text = "When you pick up gun with your right hand, timer will start.";
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
