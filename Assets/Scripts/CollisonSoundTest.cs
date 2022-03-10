using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonSoundTest : MonoBehaviour
{
    /*GameManager gameManager;
    public GameObject coliSound;*/
    public int index;
    public GameObject audioManager;
    private void Start()
    {
        //gameManager = coliSound.GetComponent<GameManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //GetComponent<AudioSource>().Play();

        //if (gameManager.)
        //{

        //}

        string audioName= audioManager.GetComponent<BrAudioManager>().GetAudio(index);
        audioManager.GetComponent<BrAudioManager>().Play(audioName);
        

        Debug.Log("PlaySound="+audioName);
    }
}