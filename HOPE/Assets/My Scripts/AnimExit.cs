using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimExit : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas breathingCanvas;
    public Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        exitButton = GetComponent<Button>();

        exitButton.onClick.AddListener(hideCanvas);

    }

    public void hideCanvas()
    {
        breathingCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }
}
