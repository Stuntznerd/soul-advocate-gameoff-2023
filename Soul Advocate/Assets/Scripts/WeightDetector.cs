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
        if (collision.gameObject.CompareTag("Soul"))
        {
            // Get color of colliding object
            string newItem = collision.gameObject.GetComponent<SoulType>().color;
    
            // Add the colliding object color to list of items
            items.Add(newItem);
    
            // Update the weight value of the pan
            weight += preferences[newItem];
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            items.Remove(collision.gameObject.GetComponent<SoulType>().color);
    
            weight = 0;
            foreach (var item in items)
            {
                weight += preferences[item];
            }
        }
    }
}
