using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toHowTo : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip soundfx;
   public void toHowToScene()
    {
        GameObject musicplayer = GameObject.FindGameObjectWithTag("audiosource");
        AudioSource audioSource = musicplayer.GetComponent<AudioSource>();
        Debug.Log(audioSource);
        audioSource.PlayOneShot(soundfx);
        SceneManager.LoadScene("How To Play");
    }
}
