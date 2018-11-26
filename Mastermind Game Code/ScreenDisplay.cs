using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDisplay : MonoBehaviour {
    public GameObject displayScreen;

	// Use this for initialization
	void Start () {
	}
	
	
    public IEnumerator displayTheScreen(float timeToWait)
    {
        yield return null;
        yield return new WaitForSeconds(timeToWait);
        displayScreen.SetActive(true);
    }
}

