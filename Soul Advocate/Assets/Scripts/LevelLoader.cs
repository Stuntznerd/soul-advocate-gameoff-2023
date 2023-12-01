using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transTime = 1f;
    public float testTime = 20f;
    void Start() {
        StartCoroutine(TestLoad(SceneManager.GetActiveScene().buildIndex + 1));
        // GameManager.OnLevelComplete += LoadNextLevel;
        // StartGame.OnStartButtonPressed += LoadNextLevel;
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator TestLoad(int levelIndex) {
        yield return new WaitForSeconds(testTime);
        
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transTime);

        SceneManager.LoadScene(levelIndex);
    }
}
