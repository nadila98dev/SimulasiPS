using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Animator Anim;
    public Image Img;

    public void Mulai()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Anim.SetBool("Fade", true);
        yield return new WaitUntil(() => Img.color.a == 1);
        SceneManager.LoadScene("Mulai");
    }
}
    
