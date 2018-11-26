//Ricky Marchant
//RickyMarchant@gmail.com
using UnityEngine;
using UnityEngine.Video;
using System.Collections;

public class movie : MonoBehaviour {
    
    public VideoPlayer vid;

    public IEnumerator PlayThenDestroy(float timeToWait)
    {
        vid.Play();
        yield return null;
        yield return new WaitForSeconds(timeToWait);
        vid.enabled = false;

    }
}
