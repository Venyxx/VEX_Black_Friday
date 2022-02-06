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
        if(GoToGame.trueIfYouSelectShopper == true)
        {
            //this will choose the shopper enemy
            Destroy (karenPlayerSelected);
            Destroy (karencamera);
            Debug.Log("deleted 1");
            Destroy(gameObject);
        }
        else 
        {
            Destroy (shopperPlayerSelected);
            Destroy (shoppercamera);
            Debug.Log("deleted 2");
            Destroy(gameObject);
        }
    }

    
}
