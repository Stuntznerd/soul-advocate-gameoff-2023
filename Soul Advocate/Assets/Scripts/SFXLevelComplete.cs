using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXLevelComplete : MonoBehaviour
{
    public AudioClip levelComplete;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GameManager.OnLevelComplete += PlayLevelCompleteSoundEffect;
    }

    public void PlayLevelCompleteSoundEffect()
    {
        audioSource.clip = levelComplete;
        audioSource.Play();
    }

}
