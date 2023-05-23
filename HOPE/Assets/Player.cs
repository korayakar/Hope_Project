using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem ripple;
    public GameObject RippleCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RippleCamera.transform.position = transform.position + Vector3.up * 10;
        Shader.SetGlobalVector("_Player", transform.position);
        
    }

    void CreateRipple(int Start, int End, int Delta, float Speed, float Size, float Lifetime)
    {
        Vector3 forward = ripple.transform.eulerAngles;
        forward.y = Start;
        ripple.transform.eulerAngles = forward;

        for (int i = Start; i < End; i += Delta)
        {
            ripple.Emit(transform.position + ripple.transform.forward * 0.5f, ripple.transform.forward * Speed, Size, Lifetime, Color.white);
            ripple.transform.eulerAngles += Vector3.up * 3;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 4)
        {
            CreateRipple(-180, 180, 3, 4, 1.25f, 3);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 4 && Time.renderedFrameCount % 10 == 0)
        {
            int y = (int)transform.eulerAngles.y;
            CreateRipple(y-100, y+100, 3, 5.4f, 1, 1.5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            CreateRipple(-180, 180, 3, 4, 1.25f, 3);
        }
    }
}
