using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            //Switches to win screen
            other.transform.Translate(5f,8f,0);
            
        }
    }
}
