using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScaleManager.OnScaleMeasurement += Rotate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rotate(int angle)
    {
        
    }
}
