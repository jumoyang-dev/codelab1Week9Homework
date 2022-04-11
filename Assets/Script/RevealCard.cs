using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealCard : MonoBehaviour
{

    public GameObject cardFront;
    public GameObject frontTexts;


    // Start is called before the first frame update
    void Start()
    {
        cardFront.SetActive(false);
        frontTexts.SetActive(false);
    }

    // Update is called once per frame
    public void Activate()
    {
        cardFront.SetActive(true);
        frontTexts.SetActive(true);
    }
}
