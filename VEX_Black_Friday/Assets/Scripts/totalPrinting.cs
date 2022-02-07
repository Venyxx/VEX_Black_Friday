using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class totalPrinting : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI totalText;
    void Start()
    {
        totalText.text = "Total: $" + CharacterControl.score.ToString();
    }

    
}
