using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbar : MonoBehaviour
{
    [SerializeField]
    private float smoothness = 1;
    private int rotationAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScaleManager.OnScaleMeasurement += setRotationAngle;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(rotationAngle);
    }

    public void Rotate(int angle)
    {
        Quaternion targetRotation = Quaternion.Euler(0,0,angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothness * Time.deltaTime);
    }

    public void setRotationAngle(int angle)
    {
        this.rotationAngle = angle;
    }
}
