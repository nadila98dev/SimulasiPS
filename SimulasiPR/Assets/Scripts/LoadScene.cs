﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void SceneLoader(string SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
       
    }

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
        
    
}
