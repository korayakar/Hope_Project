using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaryExit : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas diaryCanvas;
    public Canvas animCanvas;
    public Button diaryExitButton;
    // Start is called before the first frame update
    void Start()
    {
        diaryExitButton = GetComponent<Button>();

        diaryExitButton.onClick.AddListener(hideCanvas);
    }

    public void hideCanvas()
    {
        diaryCanvas.gameObject.SetActive(false);
        animCanvas.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
    }
}
