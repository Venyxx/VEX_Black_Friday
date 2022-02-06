using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource audioSource;
     private GameObject[] other;
     private bool NotFirst = false;
     private void Awake()
     {
         other = GameObject.FindGameObjectsWithTag("Music");
 
         foreach (GameObject oneOther in other)
         {
             if (oneOther.scene.buildIndex == -1)
             {
                 NotFirst = true;
             }
         }
 
         if (NotFirst == true)
         {
             Destroy(gameObject);
         }
         DontDestroyOnLoad(transform.gameObject);
         audioSource = GetComponent<AudioSource>();
         //stops audio from stacking on re-entry
     }
 
     
    
}
