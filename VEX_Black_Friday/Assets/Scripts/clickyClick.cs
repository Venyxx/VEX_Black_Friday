using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickyClick : MonoBehaviour
{
    // Start is called before the first frame update
    //THIS IS FOR SHOPPER
    public static bool trueIfYouSelectShopper = true;
    public AudioClip glassshatter;
    AudioSource audioSource;
    void OnMouseDown ()
    {
    
        Debug.Log("Made it to mouse down");
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(glassshatter);
        trueIfYouSelectShopper = true;
        SceneManager.LoadScene("BF Level 1");

    
    }
}
