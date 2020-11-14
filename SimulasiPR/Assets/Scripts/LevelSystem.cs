using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelSystem : MonoBehaviour

{

    private int level;
    private int userScore;
    private int userScoreToNextLevel;

    // Start is called before the first frame update
    public LevelSystem()
    {
       
    }

    // Update is called once per frame
    public void AddUserScore(float totalscore) 
    {
      if(totalscore > 30)
        {
            Debug.Log("Level is Up");
        }
    }
}
