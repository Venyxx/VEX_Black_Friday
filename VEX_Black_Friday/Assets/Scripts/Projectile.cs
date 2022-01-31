using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update Rigidbody2D rigidbody2d;

    //public int count = 0;
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
    if (transform.position.magnitude > 10000000.0f)
        {
            Destroy(gameObject);
        }
    }

    //int fixHim = 0;
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyOneControl weakestEnemy = other.collider.GetComponent<EnemyOneControl>();


        if (weakestEnemy != null)
        {
           Debug.Log("detected collison with weakest enemy");
            //kills
            weakestEnemy.e1GotHit();
        }

        
        /*FastEnemyController midStrengthEnemy = other.collider.GetComponent<FastEnemyController>();
        if (midStrengthEnemy != null)
        {
            
            RubyController.storing++;



            midStrengthEnemy.Fix();
        }

        EnemyAIController StrongestEnemy = other.collider.GetComponent<EnemyAIController>();
        if (StrongestEnemy != null)
        {
            fixHim++;
            if (fixHim == 2) { Destroy(StrongestEnemy); }


        }
        */


        //Destroy(gameObject);
    }

}
