using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging;
    private bool enterSlot;

    [HideInInspector]
    public Vector2 originalPos;
    private Vector2 slotPos;

    Slot slot;

    void Update()
    {
        if (!isDragging) return;
        print("Dragging");
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

        //if not in slot, return to original position
        if (!enterSlot)
        {     
            transform.position = originalPos;
        }//if in slot, stay in slot position
        else
        {
            transform.position = slotPos;
        }
       
        isDragging = false;
    }
    private void OnTriggerStay2D(Collider2D triggerCollider)
    {
        slot = triggerCollider.GetComponent<Slot>();
        if (triggerCollider.tag == "Slot" && !slot.occupied)
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
