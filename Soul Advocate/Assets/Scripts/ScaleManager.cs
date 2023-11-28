using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScaleManager : MonoBehaviour
{
    private int leftWeight = 0;
    private int rightWeight = 0;
    private int crossbarAngle;

    [SerializeField]
    private float rotationSpeed = 1;

    public static event Action<int, float> OnScaleMeasurement;

    // Start is called before the first frame update
    void Start()
    {
        WeightDetector.OnWeightChange += WeightChanged;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WeightChanged(int weight, string side)

    {
        if (side == "left")
        {
            leftWeight = weight;
        } else if (side == "right")
        {
            rightWeight = weight;
        }
        
        crossbarAngle = CompareWeights(leftWeight, rightWeight);
        OnScaleMeasurement?.Invoke(crossbarAngle, rotationSpeed);
    }

    public int CompareWeights(int left, int right)
    {
        int difference = left - right;

        if (Math.Abs(difference) >= 5)
        {
            return 30 * Math.Sign(difference);
        }
        else
        {
            return 6 * difference;
        }
    }
}