using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CautionTap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
void OnCollisionEnter2D(Collision2D other)
{
    CharacterControl player = other.collider.GetComponent<CharacterControl>();

        if (player != null)
        {
            Debug.Log("detected cautiontape");
            Destroy(gameObject);
            CharacterControl.scissors --;
            Debug.Log("scissors subtracted");
        }

}
    public void openTape()
    {

    }
}
