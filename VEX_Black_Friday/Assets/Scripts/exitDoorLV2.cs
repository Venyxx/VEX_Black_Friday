using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class exitDoorLV2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            //Switches to win screen
            SceneManager.LoadScene("BF Level 3");
            CharacterControl.sceneCounter++;
            
        }
    }
}