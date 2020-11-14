using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddEyeC : MonoBehaviour
{
    public ScoreSystem scorescript;

    

    public void AddOne()
    {
        scorescript.OnEyeContact(1);
        FindObjectOfType<AudioManager>().Play("PointPlus");
    }
    
}
