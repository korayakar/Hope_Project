using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallBounce : MonoBehaviour
{
    public float bounceForce = 5f;
    public float damping = 0.8f;
    private Vector3 velocity;


    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the ground
        if (collision.gameObject.CompareTag("Table"))
        {
            // Calculate the bounce direction
            Vector3 bounceDirection = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);

            // Apply the bounce force to the ball
            GetComponent<Rigidbody>().AddForce(bounceDirection * bounceForce, ForceMode.Impulse);

            velocity *= damping;

        }
     

    }

    private void FixedUpdate()
    {
        // Update the ball's velocity
        velocity = GetComponent<Rigidbody>().velocity;
    }
}


