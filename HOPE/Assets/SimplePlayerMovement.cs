using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SimplePlayerMovement : MonoBehaviourPunCallbacks
{
    public float speed = 1f;
    public float rspeed = 5f;
    public ParticleSystem ripple;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(photonView.IsMine){  

            if (Input.GetKey(KeyCode.A)){
	            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.D)){
	            transform.Translate(speed * Time.deltaTime, 0f, 0f);
            }

            if (Input.GetKey(KeyCode.W)){
	            transform.Translate(0f, 0f, speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S)){
	            transform.Translate(0f, 0f, -speed * Time.deltaTime);
            }
    
            if (Input.GetKey(KeyCode.Q)){
	            transform.Rotate(0f, -rspeed * Time.deltaTime, 0f);
            }

            if (Input.GetKey(KeyCode.E)){
	            transform.Rotate(0f, rspeed * Time.deltaTime, 0f);
            }
          }
   
            //CreateRipple(-180, 180, 3, 2, 2, 2);
        
    }

    void CreateRipple (int Start, int End, int Delta, float Speed, float Size, float Lifetime)
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

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            CreateRipple(-180, 180, 3, 2, 2, 2);
        }
    }

    private void OnTriggerStay (Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            int y = (int)transform.eulerAngles.y;
            CreateRipple(y-90, y+90, 3, 5, 2, 1);
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject.layer == 4)
        {
            CreateRipple(-180, 180, 3, 2, 2, 2);
        }
    }
}
