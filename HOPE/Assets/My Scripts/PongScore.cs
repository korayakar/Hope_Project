using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PongScore : MonoBehaviour
{
    // Start is called before the first frame update
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PongBall"))
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
