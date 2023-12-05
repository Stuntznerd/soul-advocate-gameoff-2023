using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DialogueEditor;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transTime = 1f;

    void Start() {
        StartGame.OnStartButtonPressed += LoadNextLevel;
    }

    public void LoadNextLevel() {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }
    
    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transTime);

        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator AsyncLoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transTime);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelIndex);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    void OnDisable() {
        StartGame.OnStartButtonPressed -= LoadNextLevel;
        DialogueEditor.ConversationManager.OnConversationEnded -=LoadNextLevel;
    }

    public void SubscribeToOnConversationEnded() {
        DialogueEditor.ConversationManager.OnConversationEnded += LoadNextLevel;
    }
}
