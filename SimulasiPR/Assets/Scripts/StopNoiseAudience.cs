using UnityEngine;
using UnityEngine.UI;

public class StopNoiseAudience : MonoBehaviour
{
    private bool isPlaying = false;
    public AudioSource m_AudioSource;

    public void StopNoiseBtn()
    {
        isPlaying = !isPlaying;

        if (m_AudioSource.isPlaying)
            m_AudioSource.Pause();

        else
            m_AudioSource.Play();
    
    }
}
