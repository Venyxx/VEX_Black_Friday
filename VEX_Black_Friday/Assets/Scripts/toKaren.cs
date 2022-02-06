using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toKaren : MonoBehaviour
{
    public AudioClip soundfx;
    public void toKarenScene()
    {
        GameObject musicplayer = GameObject.FindGameObjectWithTag("audiosource");
        AudioSource audioSource = musicplayer.GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundfx);
        SceneManager.LoadScene("Select Karen");
    }
}
