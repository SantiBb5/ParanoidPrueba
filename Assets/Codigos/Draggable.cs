using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public delegate void DragEndedDelegate(Draggable draggableObject);

    public DragEndedDelegate dragEndedCallback;

    public bool inPosition = false; 

    public bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    void OnMouseDown()
    {
        //print("Bonjour");
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;


    }

    void OnMouseDrag()
    {
        //print("Arrástrame papi");

        if (isDragged)
        {
            //transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);

            transform.localPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }

    }

    private void OnMouseUp()
    {
        isDragged = false;
        dragEndedCallback(this);

    }
}
