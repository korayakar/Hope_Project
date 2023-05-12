using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Write;
public class SignUpButton : MonoBehaviour
{
    public Write write = new Write();
    public Button exitbutton;
    void Start()
    {
        exitbutton.gameObject.SetActive(false);
        Button signUpButton = GetComponent<Button>();
        if(write.sendInfo())
        signUpButton.onClick.AddListener(HideCanvas);
    }

    void HideCanvas()
    {
        exitbutton.gameObject.SetActive(true);
    }
    void Update()
    {
        
    }
}
