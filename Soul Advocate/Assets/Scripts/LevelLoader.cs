using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    void Start() {
        GameManager.OnLevelComplete += LoadNextLevel;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel() {
        // TODO
    }
}
