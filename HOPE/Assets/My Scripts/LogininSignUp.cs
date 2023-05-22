using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LogininSignUp : MonoBehaviour
{
    public Canvas signupCanvas;
    public Canvas loginCanvas;
    public Button loginButton;


    public void Update()
    {
        loginButton = GetComponent<Button>();
        loginButton.onClick.AddListener(changeCanvas);
        

    }

    public void changeCanvas()
    {
        
        signupCanvas.gameObject.SetActive(false);
        loginCanvas.gameObject.SetActive(true);

     }
}
