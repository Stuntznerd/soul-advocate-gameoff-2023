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

    public static event Action<int, string> OnWeightChange;

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
            Debug.Log("Soul Entered");
            // Get color of colliding object
            GameObject newItem = collision.gameObject;

            // Add the colliding object color to list of items
            items.Add(newItem);
            Debug.Log("items: " + items.ToString());

            // Update the weight value of the pan
            string newItemColor = newItem.GetComponent<Soul>().color;
            weight += preferences[newItemColor];

            OnWeightChange?.Invoke(weight, side);

            Debug.Log("weight: " + weight);

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            collision.gameObject.transform.parent = null;
            
            Debug.Log("Soul Exited");
            items.Remove(collision.gameObject);
            Debug.Log("items: " + items.ToString());


            weight = 0;
            foreach (var item in items)
            {
                weight += preferences[item.GetComponent<Soul>().color];
            }

            OnWeightChange?.Invoke(weight, side);

            Debug.Log("weight: " + weight);
        }
    }

    private void CounterRotatePlate(int angle)
    {
        Quaternion targetRotation = Quaternion.Euler(0,0,angle);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void setRotationAngleAndSpeed(int angle, float speed)
    {
        this.rotationAngle = angle * -1;
        this.rotationSpeed = speed;
    }
}
