using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTwoControl : MonoBehaviour
{
    public float speed;
    int enemyTwoHealth;
    Rigidbody2D rb;
    Animator animator;
    private Transform player;




    float throwTimer = 4;
    private bool canThrow = true;
    public GameObject projectilePrefab;
    Vector2 lookDirection = new Vector2(1, 0);


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyTwoHealth = 2;
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
                canThrow = false;

                // Debug.Log("the enemy faces up");
            }
            else if (transform.position.x > player.position.x)
            {
                animator.SetFloat("Look X", -1);
                animator.SetFloat("Look Y", 0);
                //Debug.Log("enemy is facing left");
                canThrow = true;

            }




        }
        else if ((transform.position.x - player.position.x) < (transform.position.y - player.position.y))
        {

            if (transform.position.y > player.position.y)
            {
                animator.SetFloat("Look X", 0);
                animator.SetFloat("Look Y", -1);
                ///Debug.Log ("enemy is facing down");
                canThrow = false;
            }
            else if (transform.position.y < player.position.y)
            {
                animator.SetFloat("Look X", 1);
                animator.SetFloat("Look Y", 0);
                // Debug.Log("enemy is facing right");
                canThrow = true;
            }

        }

        if (enemyTwoHealth == 0)
        {
            Destroy(gameObject);
            //despawn
        }
        
    

    }


    void FixedUpdate()
    {
        if (enemyTwoHealth == 0)
        {
            Destroy(gameObject);
            //despawn
        }

        Vector2 position = rb.position;
        throwTimer -= Time.deltaTime;
        if (throwTimer < 0 && canThrow == true)
        {
            lookDirection.Normalize();
            GameObject projectileObject = Instantiate(projectilePrefab, rb.position + Vector2.up * 0.1f, Quaternion.identity);


            enemyProjectile projectileEnemy = projectileObject.GetComponent<enemyProjectile>();
            projectileEnemy.Launch(lookDirection, 300);

            animator.SetTrigger("Launch");
            throwTimer = 4;
            canThrow = false;
            //Debug.Log("reset throw timer" + throwTimer);
        }



    }




    void OnCollisionEnter2D(Collision2D other)
    {
        CharacterControl player = other.gameObject.GetComponent<CharacterControl>();

        if (player != null)
        {
            player.ChangeHealth(-10);
            Debug.Log("Changed player health 10");


        }
    }






    public void e2GotHit()
    {
        enemyTwoHealth -= 1;
        //Debug.Log("made it to e1gothit");


    }
}

