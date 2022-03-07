using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallColiSound : MonoBehaviour
{
    //OscillatorTest oscillatorTest;
    //GameObject osSound;

    //private void Start()
    //{
    //    oscillatorTest = osSound.GetComponent<OscillatorTest>();
        
    //}

    private void OnCollisionEnter(Collision collision)
    {

        //oscillatorTest.gain = 0.2f;
        //GetComponent<AudioSource>().Play();
        Debug.Log("PlaySound");


    }
}
