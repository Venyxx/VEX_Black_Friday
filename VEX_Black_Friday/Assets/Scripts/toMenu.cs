using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip soundfx;
    public void toMenuScript ()
    {
        CharacterControl.sceneCounter = 0;
        GameObject musicplayer = GameObject.FindGameObjectWithTag("audiosource");
        AudioSource audioSource = musicplayer.GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundfx);
        SceneManager.LoadScene("Main Menu");
    }
}
