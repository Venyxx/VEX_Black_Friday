using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOneControl : MonoBehaviour
{
    public float speed;
    int enemyOneHealth;
    Rigidbody2D rb;
    Animator animator;
    

    //bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyOneHealth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyOneHealth == 0)
        {
            Destroy(gameObject);
            //despawn
        }

    }

    void FixedUpdate()
    {
        if(enemyOneHealth == 0)
        {
            Destroy(gameObject);
            //despawn
        }

        Vector2 position = rb.position;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        CharacterControl player = other.gameObject.GetComponent<CharacterControl>();

        if (player != null)
        {
            player.ChangeHealth(-10);
            Debug.Log("Changed player health");

        }
    }

    public void e1GotHit()
    {
        enemyOneHealth -= 1;
        Debug.Log("made it to e1gothit");
        //need to figure out how to increment up more
        CharacterControl.score++;
    }
}

