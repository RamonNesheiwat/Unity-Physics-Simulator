using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forceDirection : MonoBehaviour
{
	public float currentPosition = 0;
	public float safePosition = 0;
	public Rigidbody2D rb;
	public float forceShoot = 0;
	public TrajectoryLine trajectoryLine;
	public GameObject ObjectA;
	public Vector3 forceOfDirection;
	
	public void Start()
	{
		ObjectA = GameObject.FindGameObjectWithTag("PointA"); 
		trajectoryLine = GetComponent<TrajectoryLine>(); // Needed to acess TrajectoryLine class.
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
    public void OnMouseDrag() // While holding mouse.
    {
		// Get position of ObjectA and position of this object itself.
     currentPosition = Vector2.Distance(ObjectA.transform.position, transform.position);
	 // Check if currentPosition is within maximum distance allowed, so you cant build power forever.
	 // 4 was chosen as value based on what felt natural to play.
	 if (currentPosition < 4f)
		 safePosition = currentPosition;
	 else safePosition = 4f;  // If not, set position to maximum
	 // 11 was chosen as value based on what felt natural to play.
	 // Calculates the power and direction before you release mouse
	 forceShoot = 11*(Mathf.Abs(safePosition)); // Returns value of safePosition without regard to sign.
	 // Normalize makes vector have a magnitude of 1 to keep direction of shot straight.
	//	When Normalized, a vector keeps the same direction but its length is 1.0.
	 forceOfDirection = Vector3.Normalize(ObjectA.transform.position - transform.position); // Position of Object A - this object itself.
	 // Call RenderLine method of TrajectoryLine class, pass it position of Object A - this object itself.
	 trajectoryLine.RenderLine(ObjectA.transform.position, transform.position);	
	}
	public void OnMouseUp() // When you release mouse.
	{
		// Creates the push in the direction when you release the mouse.
		Vector2 force = -(forceOfDirection * forceShoot); // Negative 1 needed since the arrow was facing the opositie direction.
		// Adds a force to the Rigidbody
		//ForceMode2D.Impluse is a built in function.
		rb.AddForce(force, ForceMode2D.Impulse); // Add an instant force impulse to the Rigidbody, takes into account mass of the object.
		// Remove arrow after you stop holding mouse
		trajectoryLine.endLine();
	}
}