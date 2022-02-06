using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGameKaren : MonoBehaviour
{
        // Start is called before the first frame update
    
//selected karen
    AudioSource audioSource;
    public AudioClip glassshatter;
     public void letsGo()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(glassshatter);
        GoToGame.trueIfYouSelectShopper = 3;
        SceneManager.LoadScene("BF Level 1");

    }
}
