using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeBlack : MonoBehaviour
{
    public int rendex;
    public string levelname;

    public int index;
    public string unloadname;

    public Image Black;
    public Animator anim;


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(Fading());
            }
        }
    }
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => Black.color.a == 1);
        {
           SceneManager.LoadScene(rendex, LoadSceneMode.Single);
           SceneManager.UnloadSceneAsync(index);
        }
    }
}