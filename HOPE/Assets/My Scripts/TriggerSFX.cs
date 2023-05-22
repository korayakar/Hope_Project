using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{

    public AudioSource playSound;

    //public AudioSource audio;

    void Awake()
    {
        playSound = GetComponent<AudioSource>();
      
    }
    
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            playSound.Play();
        }
           
  
    }
  

    


       
    
}
