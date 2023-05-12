using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class SignupText : MonoBehaviour
{
    private RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
