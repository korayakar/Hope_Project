using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitButton : MonoBehaviour
{
    public Canvas signUpCanvas;
    void Start()
    {
        Button ExitButton = GetComponent<Button>();

        ExitButton.onClick.AddListener(HideCanvas);
    }

    void HideCanvas()
    {
        signUpCanvas.gameObject.SetActive(false);
    }
    void Update()
    {

    }
}
