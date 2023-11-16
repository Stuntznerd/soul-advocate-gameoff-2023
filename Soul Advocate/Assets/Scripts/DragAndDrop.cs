using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Transform objectToDrag;
    private Rigidbody2D rb;
    private Vector2 initialMousePos;
    private Vector2 initialObjectPosition;

    void OnMouseDown()
    {
        if (IsDraggable(gameObject))
        {
            isDragging = true;
            objectToDrag = transform;
            rb = objectToDrag.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Kinematic; // Set the body type to Kinematic while dragging.
            initialMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            initialObjectPosition = objectToDrag.position;
        }
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            rb.bodyType = RigidbodyType2D.Dynamic; // Reset the body type to Dynamic when not dragging.
            objectToDrag = null;
            rb = null;

        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector2 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseDelta = currentMousePos - initialMousePos;
            objectToDrag.position = initialObjectPosition + mouseDelta;
        }
    }

    private bool IsDraggable(GameObject obj)
    {
        return obj.CompareTag("Soul");
    }
}

