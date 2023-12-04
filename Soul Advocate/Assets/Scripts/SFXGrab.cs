using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXGrab : MonoBehaviour
{
    public AudioClip grab;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start called");
        audioSource = GetComponent<AudioSource>();
        DragAndDrop.OnPickUpGem += PlayGrabSoundEffect;
    }

    public void PlayGrabSoundEffect()
    {
        audioSource.clip = grab;
        audioSource.Play();
    }

    void OnDisable() {
        DragAndDrop.OnPickUpGem -= PlayGrabSoundEffect;
    }

}
