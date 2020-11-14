using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;


public class MicrophoneInput : MonoBehaviour
{
    public float sensitivity = 100f;
    public float loudness = 0f;
    public float rmsVal;
    public float dbVal;
    public float pitchVal;

    public GameObject textDetect;

    private ScoreSystem scoresystem;
    public static int speakscore;

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;

    float[] _samples;
    private float[] _spectrum;
    private float _fSample;

    public AudioMixer AudioParameter;

   

    private string _device;

    

    // Use this for initialization
    void Start()
    {
        StartCoroutine(time());

        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 80, 44100);
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().mute = false;
        while (!(Microphone.GetPosition(null) > 0)) { GetComponent<AudioSource>().Play(); }
        //GetComponent<AudioSource>().Play();

        foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }

        _samples = new float[QSamples];
        _spectrum = new float[QSamples];
        _fSample = AudioSettings.outputSampleRate;

        

        scoresystem = GameObject.FindObjectOfType<ScoreSystem>();




    }

    IEnumerator time()
    {
        while (true)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }

    public void StopMicrophone()
    {
        Microphone.End(_device);
        _isInitialized = false;
    }





   

    // Update is called once per frame
    void Update()
    {
       

        loudness = GetAveragedVolume() * sensitivity;
        
        

       AnalyzeSound();

        

        Debug.Log("RMS: " + rmsVal.ToString("F2"));
        Debug.Log(dbVal.ToString("F1") + " dB");
        Debug.Log(pitchVal.ToString("F0") + " Hz");




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
        if (dbVal < -160) dbVal = 160; // clamp it to -160dB min
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

   

   public void timeCount()
    {
        if (pitchVal > Threshold)
        {



            textDetect.GetComponent<Text>().text = "voice normal";

            //speakscore += 1;
            //scoresystem.UpdateScore(speakscore);

            


        }
       


        else
        {
            
            textDetect.GetComponent<Text>().text = "no voice";
            speakscore = 0;
            

        }
        
    }

  

    

    float GetAveragedVolume()
    {

        float[] data = new float[256];
        float a = 0f;
        GetComponent<AudioSource>().GetOutputData(data, 0);
       

        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }

        return a / 256;

    }

    bool _isInitialized;
    // start mic when scene starts
    public void OnEnable()
    {
        Start();
        _isInitialized = true;

    }

    //stop mic when loading a new level or quit application
    public void OnDisable()
    {
        StopMicrophone();
        StopCoroutine(time());
    }

    void OnDestroy()
    {
        StopMicrophone();
        StopCoroutine(time());
    }


    // make sure the mic gets started & stopped when application gets focused
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //Debug.Log("Focus");

            if (!_isInitialized)
            {
                //Debug.Log("Init Mic");
                Start();
            }
        }
        if (!focus)
        {
            //Debug.Log("Pause");
            StopMicrophone();
            StopCoroutine(time());
            //Debug.Log("Stop Mic");
            

        }

    }

}