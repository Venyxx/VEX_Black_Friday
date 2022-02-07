using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CharacterControl : MonoBehaviour
{
    //char setup
    public float speed;
    public int maximumHealth;
    public GameObject projectilePrefab;
    public static int currentHealth;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    

    //after getting hit
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    float loserTimer = 2;




    //display
    public static int score;
    public static int scissors = 0;
    public TextMeshProUGUI scissorsDisplay;
    public TextMeshProUGUI scorePrinting;
    public GameObject winningDialog;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI loser;

    //audio
    AudioSource audioSource;
    public AudioClip throwSound;
    public AudioClip ambientSound;
    public AudioClip elevatorMusicSound;
    public AudioClip healthGrab;
    public AudioClip scissorsSound;


    public static int sceneCounter = 1;


    // Start is called before the first frame update
    void Start()
    {
        //char initialize-------------
        
        
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        //Debug.Log("got rigidbody");
        animator = GetComponent<Animator>();
        
        if(sceneCounter <= 1)
        currentHealth = maximumHealth;
        
        //Debug.Log("initial health:" + currentHealth);



        //UI initial printing--------------
        healthPrintingMethod();
        scorePrintingMethod();
        scissorsPrinting();

        

    }


    // Update is called once per frame
    void Update()
    {

        scorePrintingMethod();
        healthPrintingMethod();
        scissorsPrinting();



        //character motion values----------
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("pressed space");
            Launch();
        }
         if (Input.GetKeyDown(KeyCode.Escape))
         {           
            Debug.Log("notice esc");
            //Instantiate(loser, rigidbody2d.position + Vector2.up * 0.1f, Quaternion.identity);
            // loserTimer -= Time.deltaTime;
            // if(loserTimer < 0)
             SceneManager.LoadScene("Lose Screen");
         }


    }


    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.1f, Quaternion.identity);
        //Debug.Log(rigidbody2d.position);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        //Debug.Log(lookDirection);
        animator.SetTrigger("Launch");

        PlaySound(throwSound);

    }
    public static void addPoints(int input)
    {
        if (input == 1)
        {
            score += 15;
            //Debug.Log("added 15");
        }
        else if (input == 2)
        {
            score += 50;
        }
        else if (input == 3)
        {
            score += 100;
        }
        else if (input == 4)
        {
            score += 30;
        }

    }


    public void healthPrintingMethod()
    {
        healthText.text = "Health: " + currentHealth.ToString();
    }

    public void scorePrintingMethod()
    {
        scorePrinting.text = "Score: " + score.ToString();
    }
    public void scissorsPrinting()
    {
        scissorsDisplay.text = "Scissors: " + scissors.ToString();
    }

    void FixedUpdate()
    {
        //character motion speed values-------------
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);


    }


    public void ChangeHealth(int amount)
    {

        if (amount == 50)
        {
            PlaySound(healthGrab);
        }
        if (currentHealth <= 0)
        {
            //should it go back to the menu at this point
            //display lose screen
            Debug.Log("noticed health too low");
            SceneManager.LoadScene("Lose Screen");
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, 1000000000);
        currentHealth = currentHealth + amount;
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

        }

        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "wall" && scissors > 0)
        {
            //destroy----------------
            Debug.Log("detected cautiontape, in charact control");
            Destroy(other.gameObject);
            CharacterControl.scissors--;
            Debug.Log("scissors subtracted");
        }
        else if (other.collider.tag == "scissors")
        {
            PlaySound(scissorsSound);
        }
        
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }



}