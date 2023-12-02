using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.OnLevelComplete += StopBGM;
    }

    public void StopBGM()
    {
        if (audioSource.isPlaying) {
            audioSource.Stop();
        }
    }

}
