using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonSoundTest : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().Play();
        
        Debug.Log("PlaySound");
    }
}