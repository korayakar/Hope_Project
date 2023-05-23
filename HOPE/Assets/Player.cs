using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem ripple;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 360; i += 3)
        {
            ripple.Emit(transform.position + ripple.transform.forward, ripple.transform.forward, 2, 3, Color.white);
            ripple.transform.eulerAngles += Vector3.up * 3;
        }
        
    }
}
