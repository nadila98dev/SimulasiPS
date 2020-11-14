using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenReward : MonoBehaviour
{
    public GameObject RewardPanel;
    public GameObject Booster1;
    public GameObject Booster2;


    private void Start()
    {
        RewardPanel.SetActive(false);
    }
    public void OpenRewardPanel()
    {

        RewardPanel.SetActive(true);
        FindObjectOfType<AudioManager>().Play("WinningSound");


    }
    public void CloseReward()
    {
        RewardPanel.SetActive(false);
    }
}
