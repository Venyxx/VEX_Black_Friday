using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CharacterControl : MonoBehaviour
{
    //char setup
    public float speed = 3.0f;
    public int maximumHealth = 200;
    public GameObject projectilePrefab;
    //public int health { get { return currentHealth; } }
    public int currentHealth;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    //Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    //after getting hit
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;


    public int count;

    //display
    public static int score;
    public static int scissors;
    public TextMeshProUGUI countText;
    AudioSource audioSource;
    //public TextMeshProUGUI keyCountPrinting;
    public GameObject winningDialog;
    // public TextMeshProUGUI cogCountPrint;


    //convert to bool?
    // public static bool keyCount;
    public static int enemiesKilled;

    public static int winCondition = 0;





    // Start is called before the first frame update
    void Start()
    {
        //char initialize
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        Debug.Log("got rigidbody");
        //animator = GetComponent<Animator>();
        currentHealth = maximumHealth;
        Debug.Log("initial health:"  + currentHealth);
        //keyCount = false;

        //UI printing
        //  printing();
        //  keyPrinting();
    }


    // Update is called once per frame
    void Update()
    {

        //  keyPrinting();
        // printing();


        //character motion values
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        //animator.SetFloat("Look X", lookDirection.x);
        //animator.SetFloat("Look Y", lookDirection.y);
        //animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("pressed E");
            Launch();
        }



    }
    //interactable objects
    public GameObject healthObject;
    //public GameObject varioiuspickup;

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.1f, Quaternion.identity);
        Debug.Log(rigidbody2d.position);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        Debug.Log(lookDirection);
        //animator.SetTrigger("Launch");

        // PlaySound(throwSound);

    }
   public void addPoints(int input)
    {
        if (input == 1)
        {
            score += 15;
        }
        else if (input == 2)
        {
            score += 50;
        }
        else if (input == 3)
        {
            score += 100;
        }
    }


    public void printing()
    {
//printing
    }

    public void keyPrinting()
    {
        //key printing only matters if we have more than one key
        //keyCountPrinting.text = "key count: " + keyCount.ToString() + "/3";
    }

    void FixedUpdate()
    {
        //character motion speed values
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
        

    }


    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

        }
        Debug.Log(currentHealth);
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maximumHealth);
        if (currentHealth <= 0)
        {
            //should it go back to the menu at this point
            //display lose screen
            SceneManager.LoadScene("MainScene");
        }

    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

}