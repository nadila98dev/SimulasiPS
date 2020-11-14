﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class MicInput : MonoBehaviour
{

    int sample_size = 128;

    string micro_;

    AudioClip audio_;

    public float level_;


    void Start()
    {
        audio_ = GetComponent<AudioClip>();

        if (micro_ == null)
        {

            micro_ = Microphone.devices[0];

        }

        audio_ = Microphone.Start(micro_, true, 1, 441000);

    }


    void Update()
    {

        float[] spectrum = new float[sample_size];

        level_ = 0;

        int mic_pos = Microphone.GetPosition(null) - (sample_size + 1);

        if (mic_pos < 0)
        {

            return;

        }

        audio_.GetData(spectrum, mic_pos);

        for (int i = 0; i < spectrum.Length; i++)
        {

            float peak = spectrum[i] * spectrum[i];

            if (level_ < peak)
            {
                level_ = peak;

                Debug.Log("You are speaking");

            }

            else
            {

                Debug.Log("You are not speaking");
            }


        }


    }
}
 

 