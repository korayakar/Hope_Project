using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GolfScore : MonoBehaviour
{
    public GameObject golfBall;
    public int golfScore = 0;
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GolfBall"))
        {

            golfScore++;
            scoreText.text = "Your score is: " + golfScore.ToString();
            Invoke("PrepareForRespawn", 1);

        }
    }
    public void PrepareForRespawn()
    {
        golfBall.SetActive(false);
        RespawnBall();
    }
    void RespawnBall()
    {
        float x = 0;
        float y = 0;
        float z = 0;
        Quaternion myRotation = Quaternion.Euler(x, y, z);
        Vector3 myPosition = new Vector3(17.27993f, 0.05000189f, -68.0314f);
        golfBall.transform.position = myPosition;
        golfBall.transform.rotation = myRotation;
        golfBall.SetActive(true);
    }
    // Update is called once per frame

}
