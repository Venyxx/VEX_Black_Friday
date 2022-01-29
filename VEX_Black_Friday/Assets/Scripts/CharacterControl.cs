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
    public int health { get { return currentHealth; } }
    int currentHealth;
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
    public TextMeshProUGUI countText;
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
        Debug.Log("got rigidbody");
        //animator = GetComponent<Animator>();
        currentHealth = maximumHealth;
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

    }
    //interactable objects
    public GameObject healthObject;
    //public GameObject varioiuspickup;


    public void printing()
    {
        //we need to decide the numbers of points we need to switch levels and the maximum values that you can get on each level
      /*  if (enemiesKilled == 6 && keyCount = true)
        {
            winCondition = 2;
            Destroy(rigidbody2d);
            Instantiate(winningDialog, rigidbody2d.transform);
        }
        else if (enemiesKilled == 5 && keyCount = true)
        {
            
            winCondition = 1;





        }
        */
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
        Debug.Log(position);

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

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maximumHealth);
        if (currentHealth <= 0)
        {
            //should it go back to the menu at this point
            //display lose screen
            SceneManager.LoadScene("MainScene");
        }

    }

}