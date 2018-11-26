// Created by Ricky Marchant.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.Video;

public class createArray : MonoBehaviour
{
    //computer List created for code to be broken.
    public static List<int> compArray = new List<int>();
    public static int numberExactlyCorrect;
    public static bool allCorrect = false;
    public static bool lose = false;
    private static int totalNumberCorrect;
    private static int numberCorrectButInWrongSpot;
    private static bool removeElement0 = false;
    private static bool removeElement1 = false;
    private static bool removeElement2 = false;
    private static bool removeElement3 = false;
    //variables for Text for all objects.
    public Text numberExactlyCorrectText;
    public Text numberCorrectButInWrongSpotText;
    public Text numberExactlyCorrectText2;
    public Text numberCorrectButInWrongSpotText2;
    public Text numberExactlyCorrectText3;
    public Text numberCorrectButInWrongSpotText3;
    public Text numberExactlyCorrectText4;
    public Text numberCorrectButInWrongSpotText4;
    public Text numberExactlyCorrectText5;
    public Text numberCorrectButInWrongSpotText5;
    public Text numberExactlyCorrectText6;
    public Text numberCorrectButInWrongSpotText6;
    public Text numberExactlyCorrectText7;
    public Text numberCorrectButInWrongSpotText7;
    // 8 Might be too easy! Only add if you think necessary.
    //public Text numberExactlyCorrectText8;
    //public Text numberCorrectButInWrongSpotText8;

    //rows to be guessed variables.
    private static bool showFirstRow = true;
    private static bool showSecondRow = false;
    private static bool showThirdRow= false;
    private static bool showFourthRow = false;
    private static bool showFifthRow= false;
    private static bool showSixthRow = false;
    private static bool showSeventhRow = false;
    //private static bool showEighthRow = false;

    
    private HashSet<int> compHash = new HashSet<int>();
    private static HashSet<int> userHash= new HashSet<int>();

    private moveSubmitButton moveSButton;
    private movie successVideo;
    private movie failVideo;
    
    private GameObject winScreen;
    private GameObject loseScreen;
    private DoorController door;
    //private Animator pleaseAnim;
   
    void Start ()
    {
        createRandomNumbers();
        compArray = compHash.ToList();

        showFirstRow = true;
        //Initialize text values to empty. 
        numberExactlyCorrectText.text = " " + numberExactlyCorrect.ToString();
        numberCorrectButInWrongSpotText.text = " " + numberCorrectButInWrongSpot.ToString();
        //For second row.
        numberExactlyCorrectText2.text = " " + numberExactlyCorrect.ToString();
        numberCorrectButInWrongSpotText2.text = " " + numberCorrectButInWrongSpot.ToString();
        //For Third row.
        numberExactlyCorrectText3.text = " " + numberExactlyCorrect.ToString();
        numberCorrectButInWrongSpotText3.text = " " + numberCorrectButInWrongSpot.ToString();
        //Fourth Row.
        numberExactlyCorrectText4.text = " " + numberExactlyCorrect.ToString();
        numberCorrectButInWrongSpotText4.text = " " + numberCorrectButInWrongSpot.ToString();
        //Fifth Row.
        numberExactlyCorrectText5.text = " " + numberExactlyCorrect.ToString();
        numberCorrectButInWrongSpotText5.text = " " + numberCorrectButInWrongSpot.ToString();
        //For Sixth row.
        numberExactlyCorrectText6.text = " " + numberExactlyCorrect.ToString();
        numberCorrectButInWrongSpotText6.text = " " + numberCorrectButInWrongSpot.ToString();
        //Seventh Row.
        numberExactlyCorrectText7.text = " " + numberExactlyCorrect.ToString();
        numberCorrectButInWrongSpotText7.text = " " + numberCorrectButInWrongSpot.ToString();
        //Eighth Row. Deleted as 8 may be too easy.
        //numberExactlyCorrectText8.text = " " + numberExactlyCorrect.ToString();
        //numberCorrectButInWrongSpotText8.text = " " + numberCorrectButInWrongSpot.ToString();


        //foreach (int inda in compArray)
        //{
        //    Debug.Log("AND DIS IS " + inda);
        //}

        moveSButton = GameObject.Find("Submit Button").GetComponent<moveSubmitButton>();
        successVideo = GameObject.Find("Joker Claps").GetComponent<movie>();
        failVideo = GameObject.Find("Bear Attack").GetComponent<movie>();
        winScreen = GameObject.Find("Dwight");
        loseScreen = GameObject.Find("Bruce");
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        door = GameObject.Find("Door").GetComponent<DoorController>();
        allCorrect = false;

    }
    public void createRandomNumbers()
    {
        while (compHash.Count < 4)
            {
                compHash.Add(Random.Range(1, 7));
            }
    }

	void Update () {
        //The user lost. Teach them a lesson!
        if (lose == true)
        {
            loseScreen.SetActive(true);
            //audioScript.PlaySound("Wrong Price");
            //StartCoroutine(door.openDoor(.2f));
            
            //Values below are for regular programmed game. Above is for itch.io since movies don't play (out of my control).
            StartCoroutine(failVideo.PlayThenDestroy(7));
            StartCoroutine(door.openDoor(7));
            lose = false;
        }

    }
    //Checking for correctness between usercode and computer array.
    public static void compareArraysForExactMatches ()
    {
        if (compArray[0]==userArray.usersArray[0])
        {
            numberExactlyCorrect++;
            removeElement0 = true;
            
        }
        if (compArray[1] == userArray.usersArray[1])
        {
            numberExactlyCorrect++;
            removeElement1 = true;

        }
        if (compArray[2] == userArray.usersArray[2])
        {
            numberExactlyCorrect++;
            removeElement2 = true;
        }
        if (compArray[3] == userArray.usersArray[3])
        {
            numberExactlyCorrect++;
            removeElement3 = true;
        }
    }
    //Remove elements of computer Hash map. Needs to be in reverse order. 
    public void removeAppropriateIndexesOfArrays()
    {
        if (removeElement3 == true)
        {
            compHash.Remove(3);
        }
        if (removeElement2 == true)
        {
            compHash.Remove(2);
        }
        if (removeElement1 == true)
        {
            compHash.Remove(1);
        }
        if (removeElement0 == true)
        {
            compHash.Remove(0);
        }
    }
   //foreach loop to compare both hash maps.
    public void compareForAnyMatches()
    {
        foreach (int y in compHash)
        {
           
            foreach (int x in userHash)
            {
                if (x == y)
                {
                    totalNumberCorrect++;
                }
            }
        }
    }
    //Submit guess method.
    public void SubmitGuess()
    {
        userHash = new HashSet<int>(userArray.usersArray);
        compareArraysForExactMatches();
        compareForAnyMatches();
        numberCorrectButInWrongSpot = totalNumberCorrect - numberExactlyCorrect;
        //You win and got 4 correctly inthe right spot. Now play the win video for them!
        if (numberExactlyCorrect == 4)
        {
            //audioScript.PlaySound("Tada");
            // Code changed below since itch.io won't accept videos. 
            
            StartCoroutine(successVideo.PlayThenDestroy(4f));
            StartCoroutine(door.openDoor(4f));
            //StartCoroutine(winScreen.displayTheScreen(2f));
            winScreen.SetActive(true);
            
        }
        
        if (showFirstRow == true)
        {
            displayNumberCorrectButInWrongSpot();
            displayNumberExactlyCorrect();
            showFirstRow = false;
            showSecondRow = true;
        }
        else if (showSecondRow == true)
        {
            displayNumberCorrectButInWrongSpot2();
            displayNumberExactlyCorrect2();
            showSecondRow = false;
            showThirdRow = true;
        }
        else if (showThirdRow== true)
        {
            displayNumberCorrectButInWrongSpot3();
            displayNumberExactlyCorrect3();
            showThirdRow = false;
            showFourthRow = true;
        }
        else if (showFourthRow== true)
        {
            displayNumberCorrectButInWrongSpot4();
            displayNumberExactlyCorrect4();
            showFourthRow = false;
            showFifthRow = true;
        }
        else if (showFifthRow == true)
        {
            displayNumberCorrectButInWrongSpot5();
            displayNumberExactlyCorrect5();
            showFifthRow = false;
            showSixthRow = true;
        }
        else if (showSixthRow == true)
        {
            displayNumberCorrectButInWrongSpot6();
            displayNumberExactlyCorrect6();
            showSixthRow = false;
            showSeventhRow = true;
        }
        else if (showSeventhRow == true)
        {
            displayNumberCorrectButInWrongSpot7();
            displayNumberExactlyCorrect7();
            //showSeventhRow = false;
            //showEighthRow = true;
        }
        //else if (showEighthRow == true)
        //{
        //    displayNumberCorrectButInWrongSpot8();
        //    displayNumberExactlyCorrect8();
            
        //}

        if (numberExactlyCorrect == 4)
        {
            allCorrect = true;
        }

        //reset ALL values.
        numberExactlyCorrect = 0;

        totalNumberCorrect = 0;
        numberCorrectButInWrongSpot = 0;
        removeElement0 = false;
        removeElement1 = false;
        removeElement2 = false;
        removeElement3 = false;
        
        moveSButton.moveButton();
        userArray.usersArray[0] = 1;
        userArray.usersArray[1] = 1;
        userArray.usersArray[2] = 1;
        userArray.usersArray[3] = 1;

    }

    //Display method for first row of balls.
    public void displayNumberExactlyCorrect()
    {
        numberExactlyCorrectText.text = numberExactlyCorrect.ToString();
    }
    public void displayNumberCorrectButInWrongSpot()
    {
        numberCorrectButInWrongSpotText.text = numberCorrectButInWrongSpot.ToString();
    }
    //Display methods for second row of balls.
    public void displayNumberExactlyCorrect2()
    {
        numberExactlyCorrectText2.text = numberExactlyCorrect.ToString();
    }
    public void displayNumberCorrectButInWrongSpot2()
    {
        numberCorrectButInWrongSpotText2.text = numberCorrectButInWrongSpot.ToString();
    }
    //Display methods for third row of balls.
    public void displayNumberExactlyCorrect3()
    {
        numberExactlyCorrectText3.text = numberExactlyCorrect.ToString();
    }
    public void displayNumberCorrectButInWrongSpot3()
    {
        numberCorrectButInWrongSpotText3.text = numberCorrectButInWrongSpot.ToString();
    }
    //Display methods for fourth row.
    public void displayNumberExactlyCorrect4()
    {
        numberExactlyCorrectText4.text = numberExactlyCorrect.ToString();
    }
    public void displayNumberCorrectButInWrongSpot4()
    {
        numberCorrectButInWrongSpotText4.text = numberCorrectButInWrongSpot.ToString();
    }
    //Display methods for fifth row.
    public void displayNumberExactlyCorrect5()
    {
        numberExactlyCorrectText5.text = numberExactlyCorrect.ToString();
    }
    public void displayNumberCorrectButInWrongSpot5()
    {
        numberCorrectButInWrongSpotText5.text = numberCorrectButInWrongSpot.ToString();
    }
    //Display methods for sixth row.
    public void displayNumberExactlyCorrect6()
    {
        numberExactlyCorrectText6.text = numberExactlyCorrect.ToString();
    }
    public void displayNumberCorrectButInWrongSpot6()
    {
        numberCorrectButInWrongSpotText6.text = numberCorrectButInWrongSpot.ToString();
    }
    //Display methods for seventh row.
    public void displayNumberExactlyCorrect7()
    {
        numberExactlyCorrectText7.text = numberExactlyCorrect.ToString();
    }
    public void displayNumberCorrectButInWrongSpot7()
    {
        numberCorrectButInWrongSpotText7.text = numberCorrectButInWrongSpot.ToString();
    }
    //Display methods for eighth row.
    //public void displayNumberExactlyCorrect8()
    //{
    //    numberExactlyCorrectText8.text = numberExactlyCorrect.ToString();
    //}
    //public void displayNumberCorrectButInWrongSpot8()
    //{
    //    numberCorrectButInWrongSpotText8.text = numberCorrectButInWrongSpot.ToString();
    //}
}
