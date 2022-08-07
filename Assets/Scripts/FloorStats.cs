using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class FloorStats : MonoBehaviour
{
    public PhysicsMaterial2D physics;
	public float friction = 0.4f;
	public BoxCollider2D coll;
	
	
	void Start() 
	{
        coll = GetComponent<BoxCollider2D>();
        coll.sharedMaterial.friction = 0.4f;
		friction = 0.4f;
     }
   public void Update()
    {	
		coll.sharedMaterial.friction = friction;
		if(friction <= 0f)
		{
			coll.enabled = false;
			coll.sharedMaterial.friction = 0; 
			coll.enabled = true; // the built in friction settings seem to be partially broken. Disabling and enabling repeaditly seems to be
								//  the only way for the friction functionality to function correctly.
		}
		else if(friction >= 1)
		{
			coll.enabled = false;
			coll.sharedMaterial.friction = 1;
			coll.enabled = true;
		}	
    }
	public void updateFriction(string updateFriction) 
	{
		char negative = '-';
		string negative2 = negative.ToString();
		 //Prevent empty field or negative sign without a number crashing the game
		if((updateFriction == "") || (updateFriction == negative2))
		{
			coll.enabled = false;
			coll.sharedMaterial.friction = 0.4f; // prevent you from going through building that has a mass of 1
			coll.enabled = true;
			friction = 0.4f;
		}
		else
		 friction = float.Parse(updateFriction);
	}
}