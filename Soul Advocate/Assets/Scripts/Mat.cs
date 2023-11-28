using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Mat : MonoBehaviour
{
    private List<GameObject> souls = new();
    public static event Action OnMatEmptied;
    public static event Action OnMatFull;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Soul")) {
            souls.Add(collision.gameObject);
        }

        if (souls.Count > 0) {
            OnMatFull?.Invoke();
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Soul")) {
            souls.Remove(collision.gameObject);
        }

        if (souls.Count <= 0) {
            OnMatEmptied?.Invoke();
        }
    }
}
