using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyTwoSpawnControl : MonoBehaviour
{
   int health;
    float spawnTimer;
    public GameObject enemy;
    public SpriteRenderer spriteRenderer;
    public Sprite firstDepleteSprite;
    public Sprite secondDepleteSprite;
    private bool canSpawn = true;

    void Start()
    {
        health = 5;
        spawnTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //COMEBAKK HERRERE
        }
        else if (health <= 1)
        {
            spriteRenderer.sprite = secondDepleteSprite;
            canSpawn = false;
            
        }
        else if (health == 2)
        {
            spriteRenderer.sprite = firstDepleteSprite;
        }
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            if(canSpawn == true)
            Instantiate(enemy, gameObject.transform.position, gameObject.transform.rotation);
            spawnTimer = 2;
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "projectile")
            health -= 1;
    }
}
