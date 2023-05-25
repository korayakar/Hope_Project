using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BreathingExercise : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas breathingCanvas;
    //public Button exitButton;
    public Button breathingButton;
    // Start is called before the first frame update
    void Start()
    {
        breathingButton = GetComponent<Button>();
        breathingButton.onClick.AddListener(chanCanvas);
        breathingCanvas.gameObject.SetActive(false);
    }

    public void chanCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        breathingCanvas.gameObject.SetActive(true);
    }
}
