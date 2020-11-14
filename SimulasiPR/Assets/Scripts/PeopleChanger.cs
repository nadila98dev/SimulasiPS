using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleChanger : MonoBehaviour
{
    public GameObject people1, people2, people3, peoplechng1, peoplechng2, peoplechng3;


    public void ChangerBtn()
    {
        people1.SetActive(false);
        people2.SetActive(false);
        people3.SetActive(false);
        peoplechng1.SetActive(true);
        peoplechng2.SetActive(true);
        peoplechng3.SetActive(true);

    }

    public void DefaultPeopleBtn()
    {
        people1.SetActive(true);
        people2.SetActive(true);
        people3.SetActive(true);
        peoplechng1.SetActive(false);
        peoplechng2.SetActive(false);
        peoplechng3.SetActive(false);
    }
}
