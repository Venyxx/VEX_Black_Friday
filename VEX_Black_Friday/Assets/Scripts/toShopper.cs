using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toShopper : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip soundfx;
    public void toShopperScene()
    {
        GameObject musicplayer = GameObject.FindGameObjectWithTag("audiosource");
        AudioSource audioSource = musicplayer.GetComponent<AudioSource>();
        audioSource.PlayOneShot(soundfx);
        SceneManager.LoadScene("Select Shopper");
    }
}
