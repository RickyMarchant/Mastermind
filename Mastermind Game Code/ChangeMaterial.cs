using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour {
    public Material[] materials;
    public Renderer rend;
    public int index=1;

    void Start() {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        //initialize material to blue.
        rend.sharedMaterial = materials[index-1];
        userArray.usersArray[0] = index;
        
    }   
    
	private void OnMouseDown()
    {
        audioScript.PlaySound("changeColorSound");
        if (Input.GetMouseButtonDown(0))
        {
            index++;
            if (index==materials.Length+1)
            {
                index = 1;
                
            }
            rend.sharedMaterial = materials[index - 1];
            userArray.usersArray[0] = index;
        }
    }
}
