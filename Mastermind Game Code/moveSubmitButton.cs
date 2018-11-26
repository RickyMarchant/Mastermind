//Created by Ricky Marchant
//RickyMarchant@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveSubmitButton : MonoBehaviour
{
    public GameObject submitButton;
    public Transform transformButton;
    private int numberOfSubmits = 0;
    
    private LayerMask mask;
    //arrays since each row has multiple balls.
    //Declare everyrow! 
    private GameObject[] GORowFirst;
    private GameObject[] GORowSecond;
    private GameObject[] GORowThird;
    private GameObject[] GORowFourth;
    private GameObject[] GORowFifth;
    private GameObject[] GORowSixth;
    private GameObject[] GORowSeventh;
    //private GameObject[] GORowEighth;
    private GameObject[] GOFinalRow;

    private Button submitButtonButton;

    public void Start()
    {
        numberOfSubmits = 0;
        
        
        GORowFirst = GameObject.FindGameObjectsWithTag("Row1");
        GORowSecond= GameObject.FindGameObjectsWithTag("Row2");
        GORowThird= GameObject.FindGameObjectsWithTag("Row3");
        GORowFourth = GameObject.FindGameObjectsWithTag("Row4");
        GORowFifth = GameObject.FindGameObjectsWithTag("Row5");
        GORowSixth = GameObject.FindGameObjectsWithTag("Row6");
        GORowSeventh = GameObject.FindGameObjectsWithTag("Row7");
        //GORowEighth = GameObject.FindGameObjectsWithTag("Row8");
        GOFinalRow = GameObject.FindGameObjectsWithTag("Final Row");
        submitButtonButton = GameObject.Find("Submit Button").GetComponent<Button>();
        submitButtonButton.interactable = true;

        //Initialize each ball to be invisible at start (starting with second row).
        foreach (GameObject y in GORowSecond)
        {
            y.SetActive(false);
        }
        foreach (GameObject y in GORowThird)
        {
            y.SetActive(false);
        }
        foreach (GameObject y in GORowFourth)
        {
            y.SetActive(false);
        }
        foreach (GameObject y in GORowFifth)
        {
            y.SetActive(false);
        }
        foreach (GameObject y in GORowSixth)
        {
            y.SetActive(false);
        }
        foreach (GameObject y in GORowSeventh)
        {
            y.SetActive(false);
        }
        //foreach (GameObject y in GORowEighth)
        //{
        //    y.SetActive(false);
        //}

        //Getting duplicates when set to false. So, leave as true and hide behind the door object.
        //Also make balls unclickable.
        foreach (GameObject y in GOFinalRow)
        {
            y.SetActive(true);
        }

        foreach (GameObject x in GOFinalRow)
        {
            x.layer = mask;
        }
    }
    

    public void moveButton()
    {
        audioScript.PlaySound("submitSound");
        //make unclickable.
        mask = LayerMask.NameToLayer("Ignore Raycast");
        
        numberOfSubmits++;
        //display final answer row.
        if (numberOfSubmits == 7 && createArray.allCorrect != true)
        {
            createArray.lose = true;
            submitButtonButton.interactable = false;
        }

        if (createArray.allCorrect == true)
        {
            submitButtonButton.interactable = false;
        }
        
        //After first submission make layer for each ball gameobject so raycast is ignored.
        if (numberOfSubmits == 1)
        {
            mask = LayerMask.NameToLayer("Ignore Raycast");
            //foreach loops goes through the array of all the balls in first row.
            foreach (GameObject x in GORowFirst)
            {
                x.layer = mask;
            }
            //then active following row so it can be seen by user.
            foreach (GameObject y in GORowSecond)
            {
                if (createArray.allCorrect != true)
                {
                    y.SetActive(true);
                }
            }
            
            transformButton.transform.localPosition = new Vector3(-142, 170, 1);
            
        }
        if (numberOfSubmits == 2)
        {
            mask = LayerMask.NameToLayer("Ignore Raycast");

            foreach (GameObject x in GORowSecond)
            {
                x.layer = mask;
            }

            foreach (GameObject y in GORowThird)
            {
                if (createArray.allCorrect != true)
                    y.SetActive(true);
            }
            transformButton.transform.localPosition = new Vector3(-142, 120, 1);

        }
        if (numberOfSubmits == 3)
        {
            mask = LayerMask.NameToLayer("Ignore Raycast");

            foreach (GameObject x in GORowThird)
            {
                x.layer = mask;
            }
            foreach (GameObject y in GORowFourth)
            {
                if (createArray.allCorrect != true)
                    y.SetActive(true);
            }
            transformButton.transform.localPosition = new Vector3(-142, 70, 1);
        }

        if (numberOfSubmits == 4)
        {
            mask = LayerMask.NameToLayer("Ignore Raycast");

            foreach (GameObject x in GORowFourth)
            {
                x.layer = mask;
            }
            foreach (GameObject y in GORowFifth)
            {
                if (createArray.allCorrect != true)
                    y.SetActive(true);
            }
            transformButton.transform.localPosition = new Vector3(-142, 20, 1);
        }

        if (numberOfSubmits == 5)
        {
            mask = LayerMask.NameToLayer("Ignore Raycast");

            foreach (GameObject x in GORowFifth)
            {
                x.layer = mask;
            }
            foreach (GameObject y in GORowSixth)
            {
                if (createArray.allCorrect != true)
                    y.SetActive(true);
            }
            transformButton.transform.localPosition = new Vector3(-142, -30, 1);
        }
        if (numberOfSubmits == 6)
        {
            mask = LayerMask.NameToLayer("Ignore Raycast");

            foreach (GameObject x in GORowSixth)
            {
                x.layer = mask;
            }
            foreach (GameObject y in GORowSeventh)
            {
                if (createArray.allCorrect != true)
                    y.SetActive(true);
            }
            transformButton.transform.localPosition = new Vector3(-142, -80, 1);
        }
        if (numberOfSubmits == 7)
        {
            mask = LayerMask.NameToLayer("Ignore Raycast");

            foreach (GameObject x in GORowSeventh)
            {
                x.layer = mask;
            }
        }
        //    foreach (GameObject y in GORowEighth)
        //    {
        //        if (createArray.allCorrect != true)
        //            y.SetActive(true);
        //    }
        //    transformButton.transform.localPosition = new Vector3(-142, -130, 1);
        //}
        //if (numberOfSubmits == 8)
        //{
        //    mask = LayerMask.NameToLayer("Ignore Raycast");
        //    foreach (GameObject x in GORowEighth)
        //    {
        //        x.layer = mask;
        //    }
        //}


    }


}
