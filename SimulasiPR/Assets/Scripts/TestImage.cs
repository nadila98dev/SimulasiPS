using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestImage : MonoBehaviour
{
    private Sprite img1;
    public GameObject MyImage;

    // Start is called before the first frame update
    void Start()
    {
        MyImage.AddComponent(typeof(Image));
        img1 = Resources.Load<Sprite>("ARInfo/Magazine1/1");
        MyImage.GetComponent<Image>().sprite = img1;
        Debug.Log("Test script started");
    }
}