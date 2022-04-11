using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [HideInInspector]
    public bool occupied;

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Card")
        {
            occupied = true;
        }
    }
    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Card")
        {
            occupied = false;
        }
    }
}
