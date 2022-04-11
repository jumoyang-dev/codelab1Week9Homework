using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{

    //smooth animation timer
    float time = 0;
    //card color
    public Color backColor, frontColor;
    //reference drag and drop script
    DragAndDrop dragDrop;

    // Start is called before the first frame update
    void Start()
    {
        dragDrop = GetComponent<DragAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }



    //Vector3 newPos = new Vector3(handPos.x + (hand.Count * 3), handPos.y, 0);

    //check if it reaches the destination
    public bool MoveCard(Vector3 endPos, float duration)
    {
        //move card by using smooth step lerp function
        SmoothStepLerp(endPos, duration);
        if(Vector3.Distance(transform.position,endPos) <= 0.05f){
            time = 0; //set timer back to 0
            dragDrop.enabled = true; //when all cards are spread out, enable to move them
            //set the originalPos in DragAndDrop to the current transform
            dragDrop.originalPos = (Vector2)transform.position;
            return true;
        }
        else{ //otherwise not allow to move
            dragDrop.enabled = false;
            return false;
        }
    }
    //move card to end position in duration time
    private void SmoothStepLerp(Vector3 endPos, float duration)
    {
        Vector3 startPos = transform.position;
        if (time < duration)
        {
            //not sure this part
            float t = time / duration;
            t = t * t * (3f - 2f * t);
            //current position is divided point from start pos to end pos
            //number of division is t, which is time/duration
            transform.position = Vector3.Lerp(startPos, endPos, t);
            time += Time.deltaTime;
        }
        else
        {
            //make sure card moves to end position
            transform.position = endPos;
        }
    }
}
