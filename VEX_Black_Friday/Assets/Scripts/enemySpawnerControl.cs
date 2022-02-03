using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerControl : MonoBehaviour
{
    // Start is called before the first frame update
    int health;
    float spawnTimer;
    public GameObject enemy;
    public SpriteRenderer spriteRenderer;
    public Sprite firstDepleteSprite;
    public Sprite secondDepleteSprite;

    void Start()
    {
        health = 3;
        spawnTimer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
        }
        else if (health == 1)
        {
            spriteRenderer.sprite = secondDepleteSprite;
        }
        else if (health == 2)
        {
            spriteRenderer.sprite = firstDepleteSprite;
        }
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
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
