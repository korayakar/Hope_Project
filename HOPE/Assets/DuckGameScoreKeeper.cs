using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DuckGameScoreKeeper : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public static int score = 0;

    public void Update()
    {
        scoreText.text = score.ToString();
    }


}
