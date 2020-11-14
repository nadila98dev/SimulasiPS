using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{

    public float timeRemaining = 480;
    public bool timerIsRunning = false;
    public Text timeText;

    public Text LoadUserScore;
    public Text LoadLevelTxt;

    public static bool isGameStarted;

    public ScoreSystem scoreaddscript;
    public int adds;



    public GameObject FinishPanel;
    bool state = false;

    public AudioSource mSource;

    public static bool gameEnded = false;



    private string _device;

    private void Start()
    {
       scoreaddscript = GameObject.FindObjectOfType<ScoreSystem>();
        // Starts the timer automatically


        
            timerIsRunning = true;
            
            //FindObjectOfType<AudioManager>().Play("Classroom_Noise");
            isGameStarted = true;
        
        LoadLevelTxt.text = "Level: " + PlayerPrefs.GetInt("LevelUser").ToString();

    }

    public void Update()
    {
        if (timerIsRunning)
        {
        
            
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                FinishPanel.gameObject.SetActive(state);
                gameEnded = false;


            }
            else
            {
                //timeRemaining = 0;
                Time.timeScale = 0f;
                isGameStarted = false;
                gameEnded = true;
                
                
                timerIsRunning = false;
                

            }
            if (gameEnded == true)
            {
                Debug.Log("Time has run out!");
                StopGame();
            }
        }
    }

    public void StopGame()
    {
        state = true;
        FinishPanel.gameObject.SetActive(state);
        Microphone.End(_device);

        mSource.Stop();

        FindObjectOfType<AudioManager>().Play("Applause");
        LoadUserScore.text = PlayerPrefs.GetInt("scoreUser").ToString();
        LoadLevelTxt.text = "Level: " + PlayerPrefs.GetInt("LevelUser").ToString();
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void FinishBtn()
    {
        adds += 5;
        scoreaddscript.FinishBeforetime(adds);
        timerIsRunning = false;
        DisplayTime(timeRemaining);
        //Time.timeScale = 0f;
        StopGame();
        

    }
}