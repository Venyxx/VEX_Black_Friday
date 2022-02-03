using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scissorsControl : MonoBehaviour
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
            CharacterControl.scissors ++;
            Debug.Log("Added a scissor");
            Destroy(gameObject);
        }
    }
}
