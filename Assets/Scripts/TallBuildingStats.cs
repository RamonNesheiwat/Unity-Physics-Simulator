using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class TallBuildingStats : MonoBehaviour
{
    public Rigidbody2D rb;
	public float mass = 0;
	
   public void Update()
    {	
				  rb.mass = mass;
				 if(mass <= 0.3)
				 {
					 rb.mass = 0.3f; // prevent you from going through building that has a mass of 1
				 }
				 else if(mass >= 40)
				 {
					 rb.mass = 40f;
				 }	
    }
	public void updateMass(string updateMass) 
	{
		char negative = '-';
		string negative2 = negative.ToString();
		// Prevent empty field or negative sign without a number crashing the game
		if((updateMass == "") || (updateMass == negative2))
			mass = 1;
		else
		mass = float.Parse(updateMass);
	}
}