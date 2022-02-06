using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterDecider : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopperPlayerSelected;
    public GameObject karenPlayerSelected;
    public GameObject karencamera;
    public GameObject shoppercamera;
    
    void Start()
    {
        if(GoToGame.trueIfYouSelectShopper == 1)
        {
            //this will choose the shopper enemy
            Destroy (karenPlayerSelected);
            Destroy (karencamera);
            Debug.Log("deleted karen");
            Destroy(gameObject);
        }
        else 
        {
            Destroy (shopperPlayerSelected);
            Destroy (shoppercamera);
            Debug.Log("deleted shopper");
            Destroy(gameObject);
        }
    }

    
}
