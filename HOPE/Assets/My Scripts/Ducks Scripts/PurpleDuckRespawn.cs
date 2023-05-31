using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurpleDuckRespawn : MonoBehaviour
{
    public GameObject purpleDuck;
    public Rigidbody pRigidBody;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            pRigidBody.constraints = RigidbodyConstraints.None;
            Invoke("PrepareForRespawn", 5);
            
        }
    }
    public void PrepareForRespawn()
    {
        purpleDuck.SetActive(false);
        RespawnDuck();
    }
    void RespawnDuck()
    {
        float x = -90;
        float y = 0;
        float z = 180;
        Quaternion myRotation = Quaternion.Euler(x, y, z);
        Vector3 myPosition = new Vector3(19.16f, 0.9666176f, -36.97f);
        purpleDuck.transform.position = myPosition;
        purpleDuck.transform.rotation = myRotation;
        pRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
        purpleDuck.SetActive(true);
    }
    // Update is called once per frame

}
// GameObject newDuck = Instantiate(purpleDuck,, myRotation);
//(0.07, -1.85, -2.5), (-90, 0, 0)