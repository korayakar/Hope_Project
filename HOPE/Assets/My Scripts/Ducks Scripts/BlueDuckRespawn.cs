using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueDuckRespawn : MonoBehaviour
{
    public GameObject cyanDuck;
    public Rigidbody cRigidBody;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            cRigidBody.constraints = RigidbodyConstraints.None;
            Invoke("PrepareForRespawn", 5);

        }
    }
    public void PrepareForRespawn()
    {
        cyanDuck.SetActive(false);
        RespawnDuck();
    }
    void RespawnDuck()
    {
        float x = -90;
        float y = 0;
        float z = 180;
        Quaternion myRotation = Quaternion.Euler(x, y, z);
        Vector3 myPosition = new Vector3(21.45f, 0.9720001f, -36.92483f);
        cyanDuck.transform.position = myPosition;
        cyanDuck.transform.rotation = myRotation;
        cRigidBody.constraints = RigidbodyConstraints.FreezePositionZ;
        cyanDuck.SetActive(true);
    }
    // Update is called once per frame

}
// GameObject newDuck = Instantiate(purpleDuck,, myRotation);
//(0.07, -1.85, -2.5), (-90, 0, 0)
