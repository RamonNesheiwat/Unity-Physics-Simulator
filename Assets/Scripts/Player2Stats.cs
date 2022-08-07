using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Player2Stats : MonoBehaviour
{
    public Rigidbody2D rb2;
	private float velocity2 = 0;
	private float mass2 = 0;


   private void Update()
    {
	
				   rb2.mass = mass2;
				  if(velocity2 <= -50)
				  {
					 transform.position += new Vector3(-50 * Time.deltaTime, 0, 0);
				  }
				 else if(velocity2 >= 50)
				 {
					 transform.position += new Vector3(50 * Time.deltaTime, 0, 0);
				 }
				 else
				 transform.position += new Vector3(velocity2 * Time.deltaTime, 0, 0);
			 
				 if(mass2 <= 0.3)
				 {
					 rb2.mass = 0.3f; // prevent you from going through building that has a mass of 1
				 }
				 else if(mass2 >= 40)
				 {
					 rb2.mass = 40f;
				 }
    }
	public void updateMass2(string updateMass2) 
	{
		char negative = '-';
		string negative2 = negative.ToString();
		// Prevent empty field or negative sign without a number crashing the game
		if((updateMass2 == "") || (updateMass2 == negative2))
			mass2 = 1;
		else
		mass2 = float.Parse(updateMass2);
	}
	
	public void updateVelocity2(string updateVel2)
	{			
		char negative = '-';
		string negative2 = negative.ToString();
		// Prevent empty field or negative sign without a number crashing the game
		if((updateVel2 == "") || (updateVel2 == negative2))
			velocity2 = 0f;
		else
		velocity2 = float.Parse(updateVel2);
	}
	
	
}