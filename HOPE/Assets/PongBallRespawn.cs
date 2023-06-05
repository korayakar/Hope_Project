using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallRespawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pongBall;
    

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Table"))
        {

            Invoke("PrepareForRespawn", 2);

        }
    }
    public void PrepareForRespawn()
    {
        pongBall.SetActive(false);
        RespawnBall();
    }
    void RespawnBall()
    {
        float x = 0;
        float y = 0;
        float z = 0;
        Quaternion myRotation = Quaternion.Euler(x, y, z);
        Vector3 myPosition = new Vector3(32.6930008f, 0.79400003f, -56.7900009f);
        pongBall.transform.position = myPosition;
        pongBall.transform.rotation = myRotation;
        pongBall.SetActive(true);
        
    }
    // Update is called once per frame

}
