using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }
    
    // public event Action OnWeightChange;
    
    // public void WeightChange()
    // {
    //     if (OnWeightChange != null) {
    //         OnWeightChange();
    //     }
    // }
}
