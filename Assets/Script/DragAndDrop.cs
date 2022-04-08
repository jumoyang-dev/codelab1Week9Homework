using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging;
    private bool enterSlot;

    private Vector2 originalPos;
    private Vector2 slotPos;

    private void Awake()
    {
        originalPos = transform.position;    
    }
    void Update()
    {
        if (!isDragging) return;

        //get mousePos
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //move transform.pos of Card to mousepos
        transform.position = mousePos;
    }

    private void OnMouseDrag()
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        if (!enterSlot)
        {
            transform.position = originalPos;
        }
        else
        {
            transform.position = slotPos;
        }
       
        isDragging = false;
    }
    private void OnTriggerStay2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Slot")
        {
            enterSlot = true;
            slotPos = triggerCollider.transform.position;
        }
    }
    private void OnTriggerExit2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Slot")
        {
            enterSlot = false;
        }
    }
}
