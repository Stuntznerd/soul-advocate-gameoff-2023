// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SFXRandomizer : MonoBehaviour
// {
//     public AudioClip[] gemDropOnScale;
//     public AudioClip gemDropOnMat;
//     public AudioClip grab;
//     private AudioSource audioSource;
//     // Start is called before the first frame update
//     void Start()
//     {
//         audioSource = GetComponent<AudioSource>();
//         WeightDetector.OnGemDroppedOnScale += PlayRandomSoundEffect;
//         DragAndDrop.OnPickUpGem += SubscribeToGemDroppedOnMat;
//         DragAndDrop.OnPickUpGem += PlayGrabSoundEffect;
//     }

//     public void PlayRandomSoundEffect()
//     {
//         // Generate a random index within the audio clip array
//         int randomIndex = Random.Range(0, gemDropOnScale.Length);

//         // Select the audio clip at the random index
//         AudioClip selectedClip = gemDropOnScale[randomIndex];

//         // Assign the selected clip to the AudioSource component
//         audioSource.clip = selectedClip;

//         // Play the audio clip
//         audioSource.Play();
//     }

//     public void PlayMatSoundEffect()
//     {
//         audioSource.clip = gemDropOnMat;
//         audioSource.Play();
//     }

//     public void SubscribeToGemDroppedOnMat()
//     {
//         Mat.OnGemDroppedOnMat += PlayMatSoundEffect;
//         DragAndDrop.OnPickUpGem -= SubscribeToGemDroppedOnMat;
//     }

//     public void PlayGrabSoundEffect()
//     {
//         audioSource.clip = grab;
//         audioSource.Play();
//     }

// }
