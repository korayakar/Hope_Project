using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToDiary : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas diaryCanvas;
    //public Button exitButton;
    public Button diaryButton;
    // Start is called before the first frame update
    void Start()
    {
        diaryButton = GetComponent<Button>();
        diaryButton.onClick.AddListener(chanCanvas);
        diaryCanvas.gameObject.SetActive(false);

    }

    public void chanCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        diaryCanvas.gameObject.SetActive(true);
    }
}
