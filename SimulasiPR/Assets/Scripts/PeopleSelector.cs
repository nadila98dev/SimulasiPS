using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PeopleSelector : MonoBehaviour
{
    public Button[] peoplebtn;
    public GameObject people1, people2, people3, people4, people5;

    public GameObject peoplelvl2_1, peoplelvl2_2, peoplelvl2_3, peoplelvl2_4;

    private void Start()
    {
        int scoreReached = PlayerPrefs.GetInt("LevelUser");
        for (int i = 0; i < peoplebtn.Length; i++)
        {
            if (i + 1 > scoreReached)
               peoplebtn[i].interactable = false;



        }
    }

        public void SelectBtn10()
    {
        people1.SetActive(false);
        people2.SetActive(false);
        people3.SetActive(false);
        people4.SetActive(false);
        people5.SetActive(false);
    }

    // Update is called once per frame
    public void SelectBtn15()
    {
        people1.SetActive(true);
        people2.SetActive(true);
        people3.SetActive(true);
        people4.SetActive(true);
        people5.SetActive(true);
    }
    public void Select4()
    {
        peoplelvl2_1.SetActive(false);
        peoplelvl2_2.SetActive(false);
        peoplelvl2_3.SetActive(false);
        peoplelvl2_4.SetActive(false);
    }
    public void Select9()
    {
        peoplelvl2_1.SetActive(true);
        peoplelvl2_2.SetActive(true);
        peoplelvl2_3.SetActive(true);
        peoplelvl2_4.SetActive(true);

    }

}
