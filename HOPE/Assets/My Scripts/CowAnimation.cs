using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CowAnimation : MonoBehaviour
{
    public GameObject cow;
    
    private void Start()
    {
        cow.GetComponent<Animator>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FeedingStuff"))
        {
            StartCoroutine(StartAnimation());
        }
    }


    IEnumerator StartAnimation()
    {
        cow.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(14);
        cow.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(1);

    }
}
