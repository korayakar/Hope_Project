using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRa : MonoBehaviour
{
    public GameObject leftTeleport;
    public GameObject rightTeleport;

    public InputActionProperty leftA;
    public InputActionProperty rightA;

    public InputActionProperty leftCancel;
    public InputActionProperty rightCancel;

    // Update is called once per frame
    void Update()
    {
        leftTeleport.SetActive(leftCancel.action.ReadValue<float>() == 0 && leftA.action.ReadValue<float>() > 0.1f);
        rightTeleport.SetActive(rightCancel.action.ReadValue<float>() == 0 && rightA.action.ReadValue<float>() > 0.1f);
    }
}
//leftCancel.action.ReadValue<float>() == 0 && 
//rightCancel.action.ReadValue<float>() == 0 && 
