using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbar : MonoBehaviour
{
    private float rotationSpeed;
    private int rotationAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        ScaleManager.OnScaleMeasurement += setRotationAngleAndSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(rotationAngle);
        // RotateHJ(rotationAngle);
    }

    public void Rotate(int angle)
    {
        Quaternion targetRotation = Quaternion.Euler(0,0,angle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // public void RotateHJ(int targetAngle)
    // {
    //     HingeJoint2D hingeJoint = GetComponent<HingeJoint2D>();

    //     if (hingeJoint == null)
    //     {
    //         return;
    //     }

    //     float currentAngle = hingeJoint.jointMotor.targetAngle;
    //     float rotationDifference = targetAngle - currentAngle;

    //     // Apply motor torque to rotate towards the target
    //     hingeJoint.jointMotor.motorTorque = motorSpeed * Mathf.Sign(rotationDifference);

    //     // Check for completion
    //     if (Mathf.Abs(rotationDifference) < 0.1f)
    //     {
    //         hingeJoint.jointMotor.motorTorque = 0f;
    //     }
    // }

    public void setRotationAngleAndSpeed(int angle, float speed)
    {
        this.rotationAngle = angle;
        this.rotationSpeed = speed;
    }
}
