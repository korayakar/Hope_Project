using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using TMPro;
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Ball"))
        {
            score++;
            scoreText.text = "Good job buddy! Your score is: " + score.ToString();
      
        }
     

    }

}
