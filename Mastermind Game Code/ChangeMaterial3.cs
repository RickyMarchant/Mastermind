using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//inherits variables and methods from ChangeMaterial class
public class ChangeMaterial3 : ChangeMaterial
{
    //Overriding method from ChangeMaterial class. Since we're altering different array element here.
    public void OnMouseDown()
    {
        audioScript.PlaySound("changeColorSound");
        if (Input.GetMouseButtonDown(0))
        {
            index++;
            if (index == materials.Length + 1)
            {
                index = 1;

            }
            rend.sharedMaterial = materials[index - 1];
            userArray.usersArray[2] = index;
        }
    }
}
