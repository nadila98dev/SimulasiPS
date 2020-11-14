﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;



public class MicrophoneInputLevel : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject bulletMic;




    public GameObject green1;
    public GameObject green2;
    public GameObject green3;
    public GameObject green4;
    public GameObject green5;
    public GameObject green6;
    public GameObject green7;
    public GameObject green8;
    public GameObject green9;
    public GameObject red1;
    public GameObject red2;
    public GameObject red3;
    public GameObject red4;

    public float Speaktime = 2f;
    private float timers;
    private bool Speakon;

    public static float MicLevel;

    public int speakscore =0;
    

    private string device_;
    private AudioClip clipRecord_; 
    private int sample_ = 128;
    private bool isInitialized_;


    private ScoreSystem scoresystem;


    public float rmsVal;
    public float dbVal;
    public float pitchVal;

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;

    private float low = 0.75f;
    private float high = 1.25f;
    public Text test;


    //microphone initialization
    void InitMicrophone()
    {

        //print("InitMicrophone");
        if (device_ == null) device_ = Microphone.devices[0]; //null is the first microphone
        clipRecord_ = Microphone.Start(device_, true, 480, 44100); //record sound 10 seconds
        GetComponent<AudioSource>().clip = clipRecord_;
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().mute = false;
        while (!(Microphone.GetPosition(null) > 0)) {  }
        GetComponent<AudioSource>().Play();
        //StartCoroutine(pauseForMicRecord(10.0f)); //after 10 seconds repeat the initialization of the microphone and record sound

        scoresystem = GameObject.FindObjectOfType<ScoreSystem>();

        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;


    }



    //this method is called on each frame
    void Update()
    {

        AnalyzeSound();

        //Debug.Log("RMS: " + rmsVal.ToString("F2"));
        //Debug.Log(dbVal.ToString("F1") + " dB");
        //Debug.Log(pitchVal.ToString("F0") + " Hz");

        //depending on the volume level at the microphone input, make the images of the volume levels active
        if ((MicLevel < 0.0000001f) && (MicLevel > 0.00000001f))   
        {

            green1.SetActive(true); green2.SetActive(false); green3.SetActive(false); green4.SetActive(false); green5.SetActive(false); green6.SetActive(false); green7.SetActive(false); green8.SetActive(false); green9.SetActive(false);
            red1.SetActive(false); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            //to do something
           
        }
        if ((MicLevel < 0.000001f) && (MicLevel > 0.0000001f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(false); green4.SetActive(false); green5.SetActive(false); green6.SetActive(false); green7.SetActive(false); green8.SetActive(false); green9.SetActive(false);
            red1.SetActive(false); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            //to do something
        }
        if ((MicLevel < 0.00001f) && (MicLevel > 0.000001f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(false); green5.SetActive(false); green6.SetActive(false); green7.SetActive(false); green8.SetActive(false); green9.SetActive(false);
            red1.SetActive(false); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            //to do something
        }
        if ((MicLevel < 0.0001f) && (MicLevel > 0.00001f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(false); green7.SetActive(false); green8.SetActive(false); green9.SetActive(false);
            red1.SetActive(false); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            //to do something
        }
        if ((MicLevel < 0.001f) && (MicLevel > 0.0001f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(true); green7.SetActive(false); green8.SetActive(false); green9.SetActive(false);
            red1.SetActive(false); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            //to do something

            

        }
        if ((MicLevel < 0.010f) && (MicLevel > 0.001f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(true); green7.SetActive(false); green8.SetActive(false); green9.SetActive(false);
            red1.SetActive(false); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            //to do something
            
                
            

        }
        if ((MicLevel < 0.050f) && (MicLevel > 0.010f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(true); green7.SetActive(true); green8.SetActive(false); green9.SetActive(false);
            red1.SetActive(false); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            //to do something

            timers += Time.deltaTime;

            if (timers > 1f)
            {
                FloatingObject();

                timers = 0;
            }


        }
        if ((MicLevel < 0.070f) && (MicLevel > 0.050f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(true); green7.SetActive(true); green8.SetActive(true); green9.SetActive(false);
            red1.SetActive(false); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            //to do something

            timers += Time.deltaTime;

            if (timers > 5f)
            {
                FloatingObject();

                timers = 0;
            }



        }
        if ((MicLevel < 0.85f) && (MicLevel > 0.07f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(true); green7.SetActive(true); green8.SetActive(true); green9.SetActive(true);
            red1.SetActive(false); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            //to do something

            timers += Time.deltaTime;

            if (timers > 10f)
            {
                FloatingObject();

                timers = 0;
            }









        }
        if ((MicLevel < 0.1f) && (MicLevel > 0.85f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(true); green7.SetActive(true); green8.SetActive(true); green9.SetActive(true);
            red1.SetActive(true); red2.SetActive(false); red3.SetActive(false); red4.SetActive(false);
            
        }
        if ((MicLevel < 0.07f) && (MicLevel > 0.10f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(true); green7.SetActive(true); green8.SetActive(true); green9.SetActive(true);
            red1.SetActive(true); red2.SetActive(true); red3.SetActive(false); red4.SetActive(false);
            //to do something
        }
        if ((MicLevel < 0.10f) && (MicLevel > 0.07f))
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(true); green7.SetActive(true); green8.SetActive(true); green9.SetActive(true);
            red1.SetActive(true); red2.SetActive(true); red3.SetActive(true); red4.SetActive(false);
            //to do something
        }
        if ((MicLevel < 1.0f) && (MicLevel > 0.10f))  
        {

            green1.SetActive(true); green2.SetActive(true); green3.SetActive(true); green4.SetActive(true); green5.SetActive(true); green6.SetActive(true); green7.SetActive(true); green8.SetActive(true); green9.SetActive(true);
            red1.SetActive(true); red2.SetActive(true); red3.SetActive(true); red4.SetActive(true);
            //to do something
            //print("Very loud sound!");

        }

        

        // levelMax equals from 0.00000001f /silence, background noise/ to 0.2f /clap your hands/
        // value MicLevel is a static var, you can have access to it from anywhere
        MicLevel = LevelMax();

    }

    void AnalyzeSound()
    {
        GetComponent<AudioSource>().GetOutputData(_samples, 0); // fill array with samples
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // sum squared samples
        }
        rmsVal = Mathf.Sqrt(sum / QSamples); // rms = square root of average
        dbVal = 20 * Mathf.Log10(rmsVal / RefValue); // calculate dB
        if (dbVal < -160) dbVal = -160; // clamp it to -160dB min
                                        // get sound spectrum
        GetComponent<AudioSource>().GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        { // find max 
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;

            maxV = _spectrum[i];
            maxN = i; // maxN is the index of max
        }
        float freqN = maxN; // pass the index to a float variable
        if (maxN > 0 && maxN < QSamples - 1)
        { // interpolate index using neighbours
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        pitchVal = freqN * (_fSample / 2) / QSamples; // convert index to frequency

        
        
    }


    public void FloatingObject()
    {
         GameObject MicObject = Instantiate(bulletMic);
                MicObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                MicObject.transform.forward = playerCamera.transform.forward;
                speakscore += 10;
                scoresystem.UpdateScore(speakscore);
    }


    void StopMicrophone()
    {
        Microphone.End(device_);
    }


    //get data from microphone into audioclip
    float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[sample_];
        int micPosition = Microphone.GetPosition(null) - (sample_ + 1); // null is the first microphone
        if (micPosition < 0) return 0;
        clipRecord_.GetData(waveData, micPosition);

        //get a peak on the last 128 samples
        for (int i = 0; i < sample_; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }
        return levelMax;
    }


    // start mic when scene starts
    void OnEnable()
    {
        InitMicrophone();
        isInitialized_ = true;

    }


    //stop mic when loading a new level or quit application
    public void OnDisable()
    {
        StopMicrophone();
        
    }


    void OnDestroy()
    {
        StopMicrophone();
        
    }


    //control mic when application gets focused
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
        
            if (!isInitialized_)
            {
                InitMicrophone();
                isInitialized_ = true;
            }
        }
        if (!focus)
        {
            StopMicrophone();
            isInitialized_ = false;

        }
    }


    //after 10 seconds repeat the initialization of the microphone and record sound
    //private IEnumerator pauseForMicRecord(float pauseTime)
    //{

        //yield return new WaitForSeconds(pauseTime); //код приостановки на ... секунд (float) 
        //InitMicrophone();


    //}



}