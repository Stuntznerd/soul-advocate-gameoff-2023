using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private bool matEmpty = false;
    private int angle;
    public static event Action OnLevelComplete;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("New Scene Started");
        ScaleManager.OnScaleMeasurement += CheckWin;
        Mat.OnMatEmptied += SetMatEmptyTrue;
        Mat.OnMatFull += SetMatEmptyFalse;
    }

    public void CheckWin(int angle, float _, string motion)
    {
        if (!matEmpty) {
            return;
        }

        if (motion == "picked") {
            return;
        }

        if (angle == 0) {
            OnLevelComplete?.Invoke();
            Debug.Log("level completed");
        }
    }

    public void SetMatEmptyTrue() {
        matEmpty = true;
    }

    public void SetMatEmptyFalse() {
        matEmpty = false;
    }

}
