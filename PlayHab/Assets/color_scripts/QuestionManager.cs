using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuestionManager : MonoBehaviour
{
    public Text questionText;
    [SerializeField] private Button redButton;
    [SerializeField] private Button yellowButton;
    [SerializeField] private Button greenButton;
    [SerializeField] private Button blueButton;
    [SerializeField] private Button purpleButton;
    [SerializeField] private Button brownButton;


    private string[] catParts = { "Tail", "Face", "Paws", "Legs", "Body" };

    [SerializeField] private int numberOfParts;

    private void Start()
    {
        int randomPart = Random.Range(0, numberOfParts);
        string question = "What is the color of " + catParts[randomPart] + "?";
        questionText.text = question;

        // Implement answer button logic here
        if (randomPart == 0)
        {
            if (ColorTail.rand == 0)
                //correct answer is red
                ;
            else if(ColorTail.rand == 1)
                //correct answer is yellow
                ;
            else if(ColorTail.rand == 2)
                //correct answer is green
                ;
            else if(ColorTail.rand == 3)
                //correct answer is blue
                ;
            else if(ColorTail.rand == 4)
                //correct answer is purple
                ;
            else 
                //correct answer is brown
                ;
        }
        else if (randomPart == 1)
        {
            if (ColorFace.rand == 0)
                //correct answer is red
                ;
            else if(ColorFace.rand == 1)
                //correct answer is yellow
                ;
            else if(ColorFace.rand == 2)
                //correct answer is green
                ;
            else if(ColorFace.rand == 3)
                //correct answer is blue
                ;
            else if(ColorFace.rand == 4)
                //correct answer is purple
                ;
            else 
                //correct answer is brown
                ;
        }
        else if (randomPart == 2)
        {
            if (ColorBody.rand == 0)
                //correct answer is red
                ;
            else if(ColorBody.rand == 1)
                //correct answer is yellow
                ;
            else if(ColorBody.rand == 2)
                //correct answer is green
                ;
            else if(ColorBody.rand == 3)
                //correct answer is blue
                ;
            else if(ColorBody.rand == 4)
                //correct answer is purple
                ;
            else 
                //correct answer is brown
                ;
        }
        else if (randomPart == 3)
        {
            if (ColorArm.rand == 0)
                //correct answer is red
                ;
            else if(ColorArm.rand == 1)
                //correct answer is yellow
                ;
            else if(ColorArm.rand == 2)
                //correct answer is green
                ;
            else if(ColorArm.rand == 3)
                //correct answer is blue
                ;
            else if(ColorArm.rand == 4)
                //correct answer is purple
                ;
            else 
                //correct answer is brown
                ;
        }
        else if (randomPart == 4)
        {
            if (ColorPaws.rand == 0)
                //correct answer is red
                ;
            else if(ColorPaws.rand == 1)
                //correct answer is yellow
                ;
            else if(ColorPaws.rand == 2)
                //correct answer is green
                ;
            else if(ColorPaws.rand == 3)
                //correct answer is blue
                ;
            else if(ColorPaws.rand == 4)
                //correct answer is purple
                ;
            else 
                //correct answer is brown
                ;
        }
    }
}
