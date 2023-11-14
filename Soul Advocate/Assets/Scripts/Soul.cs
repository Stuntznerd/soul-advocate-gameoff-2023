using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//probably needs to be a scriptable object? so that it can be a template for all the soul descriptions we have
public class Soul : MonoBehaviour
{
    [SerializeField]
    public string color;

    [SerializeField]
    public string deed;
    // needs a property for sprite
    void Start()
    {
        
    }
}
