using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeightDetector : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();
    private int weight = 0;
    private Dictionary<string, int> preferences = new Dictionary<string, int>() {
        {"red", 4},
        {"yellow", 3},
        {"green", 2},
        {"blue", 1}
    };

    public static event Action<int> OnWeightChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            Debug.Log("Soul Entered");
            // Get color of colliding object
            GameObject newItem = collision.gameObject;
    
            // Add the colliding object color to list of items
            items.Add(newItem);
            Debug.Log("items: " + items.ToString());

            // Update the weight value of the pan
            string newItemColor = newItem.GetComponent<Soul>().color;
            weight += preferences[newItemColor];

            OnWeightChange?.Invoke(weight);

            Debug.Log("weight: " + weight);

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            Debug.Log("Soul Exited");
            items.Remove(collision.gameObject);
            Debug.Log("items: " + items.ToString());

    
            weight = 0;
            foreach (var item in items)
            {
                weight += preferences[item.GetComponent<Soul>().color];
            }

            OnWeightChange?.Invoke(weight);

            Debug.Log("weight: " + weight);
        }
    }
}
