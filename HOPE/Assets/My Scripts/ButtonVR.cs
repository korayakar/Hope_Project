using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class ButtonVR : MonoBehaviour
{
        public Button _button;

        void Start()
        {
            _button = GetComponent<Button>();
        }

        void Update()
        {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            _button.onClick.Invoke();
        }
  
        }
}
