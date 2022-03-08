using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColiSound : MonoBehaviour
{
    OscillatorTest oscillatorTest;
    public GameObject osSound;

    void Start()
    {
        oscillatorTest = osSound.GetComponent<OscillatorTest>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        oscillatorTest.gain = Random.Range(0f, 0.1f);
        //GetComponent<AudioSource>().Play();
        Debug.Log("PlaySound");


    }
}
