using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ExitButton : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas loginCanvas;
    public Button exitButton;
  public void Start()
    {
    exitButton = GetComponent<Button>();
        
    exitButton.onClick.AddListener(hideCanvas);
    }

    public void hideCanvas()
    {
    mainCanvas.gameObject.SetActive(false);
    loginCanvas.gameObject.SetActive(false);
    }


}