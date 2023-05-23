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

    // Update is called once per frame
    void Update()
    {
        leftTeleport.SetActive(leftA.action.ReadValue<float>() > 0.1f);
        rightTeleport.SetActive(rightA.action.ReadValue<float>() > 0.1f);
    }
}
