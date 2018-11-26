using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userArray : MonoBehaviour {
    public static int[] usersArray = { 1, 1, 1, 1 };
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            foreach(int x in usersArray)
            {
                print("Elements are : " + x);
            }
        }
      
    }
    

    
}
