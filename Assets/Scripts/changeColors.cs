using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColors : MonoBehaviour
{
 	
    void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void OnMouseExit()
    {
       GetComponent<SpriteRenderer>().color = Color.green;
    }
}