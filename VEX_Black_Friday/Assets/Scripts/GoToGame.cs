using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    // Start is called before the first frame update
public static bool trueIfYouSelectShopper = true;
    AudioSource audioSource;
    public AudioClip glassshatter;
     public void letsGo()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(glassshatter);
        trueIfYouSelectShopper = true;
        SceneManager.LoadScene("BF Level 1");

    }
}
