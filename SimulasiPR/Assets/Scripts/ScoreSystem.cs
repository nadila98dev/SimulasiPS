using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class ScoreSystem : MonoBehaviour
{
    private LevelSystem levelsystem;
    public GameObject scoreText;
    private bool haseye;
    private TimerCountDown timerCountDown;
    public Text speakpercnt;
    public Text ScoreText;
    public Text EyeText;
    public Text TextAddPoint;
    
    public int theEyeC;
    public int EyeCurrentScore;
    public int additionalpoint;
    private int score;
    private int currentScore;
    public int totalscore;


    public int levelnum;

    public static ScoreSystem instance;



    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    private void Start()
    {

        theEyeC = 0;
        haseye = false;

        score = 0;
   

    }

    public void OnEyeContact(int adjust)
    {

        theEyeC += adjust;
        haseye = true;
        
        EyeText.text =  theEyeC.ToString();


        TotalScoreMethod();


    }
    public void FinishBeforetime(int adds)
    {

        additionalpoint += adds;
        TextAddPoint.text = "Bonus:       " + additionalpoint;

        TotalScoreMethod();

    }

    public void UpdateScore(int speakscore)
    {


        //EyeCurrentScore = theEyeC;

        currentScore = speakscore;
            speakpercnt.text = currentScore.ToString();

       
        totalscore = currentScore;
       
        TotalScoreMethod();
                  

        //soreText.GetComponent<Text>().text = "Eye Contact " + theEyeC.ToString();
    }

    public void TotalScoreMethod()
    {

        score = totalscore + additionalpoint + theEyeC;
        ScoreText.text = "Score:      " + score.ToString();

        //levelsystem.AddUserScore(totalscore);
        if (score > PlayerPrefs.GetInt("scoreUser"))
        {
            PlayerPrefs.SetInt("scoreUser", score);
        }

        LevelManager();

    }

    public void BacktoSelection()
    {
        SceneManager.LoadScene(1);
    }


    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
    
    public void LevelManager()
    {
        if(PlayerPrefs.GetInt("scoreUser") > 80)
        {
            levelnum =1;
            PlayerPrefs.SetInt("LevelUser", levelnum);

        }
        if (PlayerPrefs.GetInt("scoreUser") > 160)
        {
            levelnum = 2;
            PlayerPrefs.SetInt("LevelUser", levelnum);

        }
        if (PlayerPrefs.GetInt("scoreUser") > 240)
        {
            levelnum = 3;
            PlayerPrefs.SetInt("LevelUser", levelnum);

        }

    }

}
