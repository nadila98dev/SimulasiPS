using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public bool isUnlock;

    GameObject targetGameobject;

    public GameObject lockpanel;

    public Text LevelUserText;
    public SceneFader fader;

    public Button[] levelButtons;

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("LevelUser", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i + 1 > levelReached)
            levelButtons[i].interactable = false;
            


        }
        UILevelSelection();
    }

    public void UILevelSelection()
    {
        LevelUserText.text = PlayerPrefs.GetInt("LevelUser").ToString();
    }

   

    public void Select(string SceneName)
    {
        
        SceneManager.LoadScene(SceneName);
    }


   
}
