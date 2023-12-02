using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartGame : MonoBehaviour
{
    public static event Action OnStartButtonPressed;

    public void LoadLevel()
    {
        OnStartButtonPressed?.Invoke();
    }
}
