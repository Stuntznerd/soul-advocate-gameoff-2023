using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transTime = 1f;
    // public float testTime = 20f;
    void Start() {
        // StartCoroutine(TestLoad(SceneManager.GetActiveScene().buildIndex + 1));
        GameManager.OnLevelComplete += LoadNextLevel;
        // StartGame.OnStartButtonPressed += LoadNextLevel;
        Debug.Log("Level Loader: " + this.GetInstanceID().ToString());
        Debug.Log("Loaded Scenes: " + SceneManager.loadedSceneCount.ToString());
        Debug.Log("Scenes: " + SceneManager.sceneCount.ToString());
    }

    public void LoadNextLevel() {
        GameManager.OnLevelComplete -= LoadNextLevel;
        Debug.Log("Before start coroutine");
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        Debug.Log("After coroutine");
        // StartCoroutine(AsyncLoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    IEnumerator LoadLevel(int levelIndex) {
        Debug.Log("1");
        transition.SetTrigger("Start");

        Debug.Log("2");
        yield return new WaitForSeconds(transTime);

        Debug.Log("3");
        SceneManager.LoadScene(levelIndex);

        Debug.Log("4");
    }

    // IEnumerator TestLoad(int levelIndex) {
    //     yield return new WaitForSeconds(testTime);

    //     transition.SetTrigger("Start");

    //     yield return new WaitForSeconds(transTime);

    //     SceneManager.LoadScene(levelIndex);
    // }

    // IEnumerator AsyncLoadLevel(int levelIndex) {
    //     transition.SetTrigger("Start");

    //     yield return new WaitForSeconds(transTime);

    //     AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);

    //     while (!asyncLoad.isDone)
    //     {
    //         yield return null;
    //     }
    // }
}
