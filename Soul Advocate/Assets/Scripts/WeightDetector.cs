using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeightDetector : MonoBehaviour
{
    private int rotationAngle;
    private float rotationSpeed;
    private List<GameObject> items = new();
    private int weight = 0;
    private Dictionary<string, int> preferences = new() {
        {"red", 4},
        {"yellow", 3},
        {"green", 2},
        {"blue", 1}
    };

    [SerializeField]
    private string side = "left";

    public static event Action<int, string, string> OnWeightChange;
    public static event Action OnGemDroppedOnScale;

    // Start is called before the first frame update

    void Start()
    {
        ScaleManager.OnScaleMeasurement += setRotationAngleAndSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        CounterRotatePlate(rotationAngle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            collision.gameObject.transform.parent = transform;
            // Get color of colliding object
            GameObject newItem = collision.gameObject;

            // Add the colliding object color to list of items
            items.Add(newItem);

            // Update the weight value of the pan
            string newItemColor = newItem.GetComponent<Soul>().color;
            weight += preferences[newItemColor];

            OnGemDroppedOnScale?.Invoke();
            OnWeightChange?.Invoke(weight, side, "dropped");
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            collision.gameObject.transform.parent = null;
            
            items.Remove(collision.gameObject);

            weight = 0;
            foreach (var item in items)
            {
                weight += preferences[item.GetComponent<Soul>().color];
            }

            OnWeightChange?.Invoke(weight, side, "picked");
        }
    }

    private void CounterRotatePlate(int angle)
    {
        Quaternion targetRotation = Quaternion.Euler(0,0,angle);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void setRotationAngleAndSpeed(int angle, float speed, string _)
    {
        this.rotationAngle = angle * -1;
        this.rotationSpeed = speed;
    }
}
