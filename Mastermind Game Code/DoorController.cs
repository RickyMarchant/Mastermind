using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {
    GameObject door;
    Animator animator;
	// Use this for initialization
	void Start () {
        door = GameObject.Find("Door");
        animator = door.GetComponent<Animator>();
	}
    public IEnumerator openDoor(float timeToWait)
    {
        yield return null;
        yield return new WaitForSeconds(timeToWait);
        bool isOpening = true;
        animator.SetBool("isOpening", isOpening);
    }
}

