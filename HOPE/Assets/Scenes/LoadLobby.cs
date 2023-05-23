using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
public class LoadLobby : MonoBehaviour
{

    public InputActionProperty rightA;

    // Update is called once per frame
    void Update()
    {
       if(rightA.action.ReadValue<float>() > 0.1f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
