using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Player1Stats : MonoBehaviour
{
    public Rigidbody2D rb;
	public float velocity = 0;
	public float mass = 0;
	
   public void Update()
    {	
				  rb.mass = mass;
				  if(velocity <= -50)
				  {
					 transform.position += new Vector3(-50 * Time.deltaTime, 0, 0);
				  }
				 else if(velocity >= 50)
				 {
					 transform.position += new Vector3(50 * Time.deltaTime, 0, 0);
				 }
				 else
				 transform.position += new Vector3(velocity * Time.deltaTime, 0, 0);
			 
				 if(mass <= 0.3)
				 {
					 rb.mass = 0.3f; // prevent you from going through building that has a mass of 1
				 }
				 else if(mass >= 40)
				 {
					 rb.mass = 40f;
				 }	
    }
	public void updateVelocity(string updateVel) 
	{
		char negative = '-';
		string negative2 = negative.ToString();
		// Prevent empty field or negative sign without a number crashing the game
		if((updateVel == "") || (updateVel == negative2))
			velocity = 0;
		else
		velocity = float.Parse(updateVel);
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