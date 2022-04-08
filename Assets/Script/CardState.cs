using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{

    float time = 0;
    public Color backColor, frontColor; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }



    //Vector3 newPos = new Vector3(handPos.x + (hand.Count * 3), handPos.y, 0);

    //check if it reaches the destination
    public bool MoveCard(Vector3 endPos, float duration)
    {
        SmoothStepLerp(endPos, duration);
        if(Vector3.Distance(transform.position,endPos) <= 0.05f){
            time = 0;
            return true;
        }
        else{
            return false;
        }
    }

    private void SmoothStepLerp(Vector3 endPos, float duration)
    {
        Vector3 startPos = transform.position;
        if (time < duration)
        {
            float t = time / duration;
            t = t * t * (3f - 2f * t);
            transform.position = Vector3.Lerp(startPos, endPos, t);
            time += Time.deltaTime;
        }
        else
        {
            transform.position = endPos;
        }
    }
}
