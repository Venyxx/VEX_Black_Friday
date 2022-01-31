using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
     //public AudioClip collectedClip;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        
        CharacterControl controller = other.GetComponent<CharacterControl>();

        //ParticleSystem ps = GameObject.Find("healthBurst").GetComponent<ParticleSystem>();

        if (controller != null)
        {
            Debug.Log("contact with health and character");
            if (controller.currentHealth < controller.maximumHealth)
            {
                //adds 50 health to character
                controller.ChangeHealth(50);
                //Instantiate(healthBurst, controller.transform.position, controller.transform.rotation);
                Destroy(gameObject);


                Debug.Log("collided with health pickup");

                //controller.PlaySound(collectedClip);

            }
        }

    }
}
