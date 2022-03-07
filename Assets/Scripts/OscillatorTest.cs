using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatorTest : MonoBehaviour
{
    BallColiSound ballColiSound;
    public GameObject osSound;

    public double frequency = 440.0;
    private double increment;
    private double phase;
    private double sampling_frequency = 48000.0;

    public float gain;
    //public float volume = 1.0f;

    //public float[] frequencies;
    //public int thisFreq;

    private void Awake()
    {
        //BallColiSound ballColiSound;
        ballColiSound = osSound.GetComponent<BallColiSound>();
    }

    private void Update()
    {
        if (ballColiSound == isActiveAndEnabled)
        {
            gain = Random.Range(0f, 0.1f);
        }
    }



    private void OnAudioFilterRead(float[] data, int channels)
    {
        increment = frequency * 2.0 * Mathf.PI / sampling_frequency;

        for(int i =0; i<data.Length; i += channels)
        {
            phase += increment;
            data[i] = (float)(gain * Mathf.Sin((float)phase));

            if (channels == 2)
            {
                data[i + 1] = data[i];
            }

            if (phase > (Mathf.PI * 2))
            {
                phase = 0.0;
            }



        }
    }

}
