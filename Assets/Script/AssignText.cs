using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class AssignText : MonoBehaviour
{
    //string content;
    //const char DELIMITER = '|';
    //const string FILE_NAME = "CardText.txt";
    
    // Start is called before the first frame update

    public List<string> cardText = new List<string>();

    void Start()
    {
       //StreamReader reader = new StreamReader(FILE_NAME);
       //content = reader.ReadLine();

       //char[] delimiterChars = { '|' };
       //string[] textSplit = content.Split(delimiterChars);

       //Debug.Log(textSplit[0]);
       //Debug.Log(textSplit[1]);
       
       //reader.Close();


       cardText.Add("Mario is a robber.");
       cardText.Add("The Kingdom of the peaceful mushroom people was invaded by the Koopa.");
       cardText.Add("Mario kills a large number of mushroom people.");
       cardText.Add("Mario steals a lot of gold and money.");
       cardText.Add("Koopa is mad. ");
       cardText.Add("Mario defeats Koopa.");
       cardText.Add("Mario snatches the princess away.");
       cardText.Add("Princess is happy.");
       cardText.Add("Mushroom people are smiling.");

       Debug.Log(cardText[3]);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
