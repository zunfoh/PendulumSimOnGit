using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonSoundTest : MonoBehaviour
{
    GameManager gameManager;
    public GameObject coliSound;

    private void Start()
    {
        gameManager = coliSound.GetComponent<GameManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //GetComponent<AudioSource>().Play();

        //if (gameManager.)
        //{

        //}
    
        
        //FindObjectOfType<BrAudioManager>().Play("do");
        

        Debug.Log("PlaySound");
    }
}