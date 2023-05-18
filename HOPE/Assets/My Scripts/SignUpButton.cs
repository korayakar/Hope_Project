using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Write;
public class SignUpButton : MonoBehaviour
{
    public Write write = new Write();
   
    void Start()
    {
        Button signUpButton = GetComponent<Button>();
        Button exitbutton = GetComponent<Button>();
        exitbutton.gameObject.SetActive(false);
        
        signUpButton.onClick.AddListener(showButton);
    }

    void showButton()
    {
      
    }
    void Update()
    {
        
    }
}
