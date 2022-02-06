using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectile : MonoBehaviour
{
 Rigidbody2D projectileRB;


    void Awake()
    {
        projectileRB = GetComponent<Rigidbody2D>();

    }

    public void Launch(Vector2 direction, float force)
    {
        projectileRB.AddForce(direction * force);
    }

    void Update()
    {
        //destroy with distance        
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
 
    void OnCollisionEnter2D(Collision2D other)
    {


        CharacterControl player = other.collider.GetComponent<CharacterControl>();
        if (player != null)
        {
            player.ChangeHealth(-4);

        }

        Destroy(gameObject);
    }
}
