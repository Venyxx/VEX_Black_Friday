using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyThreeControl : MonoBehaviour
{
    // Start is called before the first frame update
  public float speed;
    int enemyOneHealth;
    Rigidbody2D rb;
    Animator animator;
    private Transform player;
    public float enemyspeed = 3f;
    

    public Animation enemyoneup;
    public Animation enemyoneleft;
    public Animation enemyoneright;
    public Animation enemyonedown;
    public Animation enemyoneidle;


    //bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyOneHealth = 6;
    }
    // Update is called once per frame
    void Update()
    {
        //movement
        if (Vector2.Distance(transform.position, player.position) > 0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }


        //rotation detection
        //if the difference horizontally is larger than vertically
        if ((transform.position.x - player.position.x) > (transform.position.y - player.position.y))
        {
            //check for x comparison
            //is the player above or below 
             //check if left or right
                if (transform.position.x < player.position.x)
                {
                   animator.SetFloat("Look X", 0);
                   animator.SetFloat("Look Y", 1);
                    
                   // Debug.Log("the enemy faces up");
                }
                else if (transform.position.x > player.position.x)
                {
                    animator.SetFloat("Look X", -1);
                   animator.SetFloat("Look Y", 0);
                    //Debug.Log("enemy is facing left");
                }
            
                
            
            
        }else if ((transform.position.x - player.position.x) < (transform.position.y - player.position.y))
        {

            if (transform.position.y > player.position.y)
            {
                animator.SetFloat("Look X", 0);
                   animator.SetFloat("Look Y", -1);
                ///Debug.Log ("enemy is facing down");
            }
            else if (transform.position.y < player.position.y)
            {
               animator.SetFloat("Look X", 1);
                   animator.SetFloat("Look Y", 0);
               // Debug.Log("enemy is facing right");
            }

        }

        if (enemyOneHealth == 0)
        {
            Destroy(gameObject);
            //despawn
        }

        

    }

    void FixedUpdate()
    {
        if (enemyOneHealth == 0)
        {
            Destroy(gameObject);
            //despawn
        }

        Vector2 position = rb.position;
    }
    int timer;
   
    void OnCollisionEnter2D(Collision2D other)
    {
        CharacterControl player = other.gameObject.GetComponent<CharacterControl>();

        if (player != null)
        {
            player.ChangeHealth(-20);
            Debug.Log("Changed player health");
            

        }
    }

    public void e3GotHit()
    {
        enemyOneHealth -= 1;
        //Debug.Log("made it to e1gothit");
        
        
    }
}

