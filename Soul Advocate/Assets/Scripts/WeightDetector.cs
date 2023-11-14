using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightDetector : MonoBehaviour
{
    private List<string> items = new List<string>();
    private int weight = 0;
    private Dictionary<string, int> preferences = new Dictionary<string, int>();

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
        // Get color of colliding object
        newItem = collision.gameObject.GetComponent<Color>().color;

        // Add the colliding object color to list of items
        items += newItem;

        // Update the weight value of the pan
        weight += preferences[newItem];

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        items.Remove(collision.gameObject.GetComponent<Color>().color)

        weight = 0
        foreach (var item in items)
        {
            weight += preferences[item]
        }
    }
}
