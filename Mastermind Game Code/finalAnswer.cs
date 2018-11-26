using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalAnswer : MonoBehaviour
{
    public Material[] materials;
    public Renderer rend;
    public int index = 1;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[index-1];
        StartCoroutine(updateColor());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            updateColor();
        }
    }
    IEnumerator updateColor()
    {
        yield return null;
        yield return new WaitForSeconds(.1f);
        index++;
            if (index == materials.Length + 1)
            {
                index = 1;
            }
            index = createArray.compArray[0];
            rend.sharedMaterial = materials[index - 1];
        
        
               
    }

}
