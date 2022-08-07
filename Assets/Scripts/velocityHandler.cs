using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class velocityHandler : MonoBehaviour
{
    public Rigidbody2D rb;
	public InputField velocityInput;	
	public float velocity = 0;


   public void Update()
    {
	
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
		
    }
	
	public void updateVelocity(string updateVel)
	{
				
		char negative = '-';
		string negative2 = negative.ToString();
		// Prevent empty field or negative sign without a number crashing the game
		if((updateVel == "") || (updateVel == negative2))
			velocity = 0f;
		else
		velocity = float.Parse(updateVel);
		
	}
	
}