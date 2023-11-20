using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScaleManager : MonoBehaviour
{
    private int leftWeight = 0;
    private int rightWeight = 0;
    private int crossbarAngle;

    public static event Action<int> OnScaleMeasurement;

    // Start is called before the first frame update
    void Start()
    {
        WeightDetector.OnWeightChange += WeightChanged;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WeightChanged();
    {
        crossbarAngle = CompareWeights(leftWeight, rightWeight);
        OnScaleMeasurement?.Invoke(crossbarAngle);
    }

    public int CompareWeights(int left, int right)
    {

        if((left - right) >= 5) {
            return -40;
        }
        else if ((left - right) == 4) {
            return -32;
        }
        else if ((left - right) == 3) {
            return -24;
        }
        else if ((left - right) == 2) {
            return -16;
        }
        else if ((left - right) == 1) {
            return -8;
        }

        if ((right - left) >= 5) {
            return 40;
        }
        else if ((right - left) == 4) {
            return 32;
        }
        else if ((right - left) == 3) {
            return 24;
        }
        else if ((right - left) == 2) {
            return 16;
        }
        else if ((right - left) == 1) {
            return 8;
        }

        // left == right
        return 0;
    }
}
