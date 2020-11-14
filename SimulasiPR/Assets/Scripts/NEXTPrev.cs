using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System.Collections;


public class NEXTPrev : MonoBehaviour
{
    public GameObject[] mailPrefab;

    public GameObject[] mailPrefab2;


    int currentIndex = 0;

    //sets everything except the first gameObject to inactive
    void Awake()
    {
        if (mailPrefab.Length > 0) //you might not need this check, but it will catch any weird edge cases
        {
            for (int i = 1; i < mailPrefab.Length; ++i)
            {
                mailPrefab[i].SetActive(false);


            }
            
            
        }
    }
    public int CurrentIndex
    {
        get
        {
            return currentIndex;
        }
        set
        {
            if (mailPrefab[currentIndex] != null)
            {
                //set the current active object to inactive, before replacing it
                GameObject aktivesObj = mailPrefab[currentIndex];
                aktivesObj.SetActive(false);
            }

            if (value < 0)
                currentIndex = mailPrefab.Length - 1;
            else if (value > mailPrefab.Length - 1)
                currentIndex = 0;
            else
                currentIndex = value;
            if (mailPrefab[currentIndex] != null)
            {
                GameObject aktivesObj = mailPrefab[currentIndex];
                aktivesObj.SetActive(true);
            }

            


        }
    }
         public void Next(int direction)
    {
        direction = 0;
        CurrentIndex++;
        
    }
    public void Previous(int direction)
    {
        direction = 1;
        CurrentIndex--;
        
    }
}
