using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioScript : MonoBehaviour {
    public static AudioClip CC1Sound, CC2Sound, CC3Sound, winSound, loseSound;
    static AudioSource audioSrc;
    public static bool isMuted = false;
    

	// Use this for initialization
	void Start () {
        CC1Sound = Resources.Load<AudioClip>("CC1");
        CC3Sound = Resources.Load<AudioClip>("CC3");
        winSound = Resources.Load<AudioClip>("Tada");
        loseSound = Resources.Load<AudioClip>("Wrong Price"); 
        audioSrc = GetComponent<AudioSource>();
	}
    public static void PlaySound(string clip)
    {
        if (isMuted == false)
        {
            switch (clip)
            {
                case "changeColorSound":
                    audioSrc.PlayOneShot(CC3Sound);
                    break;

                case "submitSound":
                    audioSrc.PlayOneShot(CC1Sound);
                    break;
                case "Tada":
                    audioSrc.PlayOneShot(winSound);
                    break;
                case "Wrong Price":
                    audioSrc.PlayOneShot(loseSound);
                    break;


            }
        }

    }
    //Flip flop mute.
    public void Mute()
    {
        if (isMuted == false)
        {
            isMuted = true;
        }
        else if (isMuted == true)
        {
            isMuted = false;
        }       
    }
}
