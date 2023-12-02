using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Transform objectToDrag;
    private Rigidbody2D rb;
    private Vector3 initialMousePos;
    private Vector3 initialObjectPosition;
    private int initialSortingOrder;
    private Vector3 objPosAtSceneStart;
    public static event Action OnPickUpGem;

    void Start()
    {
        objPosAtSceneStart = transform.position;
    }

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

            initialSortingOrder = 6;
            objectToDrag.GetComponent<Renderer>().sortingOrder = 1000;
            OnPickUpGem?.Invoke();
        }
    }

    void OnMouseDrag()
    {
        Vector3 currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDelta = currentMousePos - initialMousePos;
        objectToDrag.position = initialObjectPosition + mouseDelta;
    }

    void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            rb.bodyType = RigidbodyType2D.Dynamic; // Reset the body type to Dynamic when not dragging.
            objectToDrag.GetComponent<Renderer>().sortingOrder = initialSortingOrder;

            // Perform raycast to check if the soul is dropped on a plate
            RaycastHit2D hit = Physics2D.Raycast(objectToDrag.position, Vector2.zero, 10f, ~(1 << gameObject.layer));
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Plate"))
                {
                    objectToDrag.GetComponent<Renderer>().sortingOrder = 0;
                }
                else if (!hit.collider.CompareTag("Mat"))
                {
                    // If not dropped on a plate or mat, reset to initial position on the mat
                    objectToDrag.position = objPosAtSceneStart;
                }
            }
            else
            {
                objectToDrag.position = objPosAtSceneStart;
            }

            objectToDrag = null;
            rb = null;
        }
    }

    private bool IsDraggable(GameObject obj)
    {
        return obj.CompareTag("Soul");
    }
}




