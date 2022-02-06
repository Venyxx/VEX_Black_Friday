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
    if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }
    public static void addPointsToScoreInMainScript (int input)
    {
        CharacterControl.addPoints(input);
    }
    //int fixHim = 0;
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyOneControl weakestEnemy = other.collider.GetComponent<EnemyOneControl>();


        if (weakestEnemy != null)
        {
           Debug.Log("detected collison with weakest enemy");
           addPointsToScoreInMainScript(1);

            //kills
            weakestEnemy.e1GotHit();
        }

        
        enemyTwoControl midStrengthEnemy = other.collider.GetComponent<enemyTwoControl>();
        if (midStrengthEnemy != null)
        {
            
            addPointsToScoreInMainScript(2);
            midStrengthEnemy.e2GotHit();
            
        }

        enemyThreeControl StrongestEnemy = other.collider.GetComponent<enemyThreeControl>();
        if (StrongestEnemy != null)
        {
           
            addPointsToScoreInMainScript(3);
            StrongestEnemy.e3GotHit();

        }
    


        Destroy(gameObject);
    }

}
