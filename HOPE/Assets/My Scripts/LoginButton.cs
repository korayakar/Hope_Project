using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginButton : MonoBehaviour
{
    public Canvas signupCanvas;
    public Canvas loginCanvas;
    public Button loginButton;

    public Write2 write2 = new Write2();
    public void Start()
    {

        loginButton.onClick.AddListener(changeCanvas); 
        loginButton = GetComponent<Button>();
   
    }

    public void changeCanvas()
    {

    }



    


}