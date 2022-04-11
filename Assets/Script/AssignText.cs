using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class AssignText : MonoBehaviour
{

    public List<string> cardTextList = new List<string>();
    public List<Text> thisCardText = new List<Text>();
    // public Text text1;
    // public Text text2;
    // public Text text3;
    // public Text text4;
    // public Text text5;

    void Start()
    {


       cardTextList.Add("Mario is a robber.");
       cardTextList.Add("The Kingdom of the peaceful mushroom people was invaded by the Koopa.");
       cardTextList.Add("Mario kills a large number of mushroom people.");
       cardTextList.Add("Mario steals a lot of gold and money.");
       cardTextList.Add("Koopa is mad. ");
       cardTextList.Add("Mario defeats Koopa.");
       cardTextList.Add("Mario snatches the princess away.");
       cardTextList.Add("Princess is happy.");
       cardTextList.Add("Mushroom people are smiling.");

       //Debug.Log(cardTextList[3]);
       //Debug.Log(cardTextList.Count);



    }

    // Update is called once per frame
    void Update()
    {
        //string thisCardText = cardTextList[2];
        int count = 1;
        
        for (int i = cardTextList.Count-1; i >=4 ; i--)
        {
            
            int number = Random.Range(0, cardTextList.Count-1);
            thisCardText[count-1].text = cardTextList[number];
            cardTextList.Remove(cardTextList[number]);
            Debug.Log(cardTextList[number]);
            count ++;

         }

        //txet1.text = 


    }
}
