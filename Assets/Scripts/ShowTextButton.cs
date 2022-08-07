using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;



class ShowTextButton : MonoBehaviour
 {
	 public bool showTextPlayer = false;
	 private string velocityString = "";
	 private string massString = "";
	 private Vector2 toMouse;
	 private RaycastHit2D hit;
	 public Player1Stats stats;
	 public ShowTextButton2 textButton2;
	 public ShowTextButtonBuilding textButtonBuilding;
	 public ShowTextButtonFloor textButtonFloor;


	 
	private void Start()
	 {
		 stats  = GameObject.FindObjectOfType<Player1Stats>(); 
		 textButton2  = GameObject.FindObjectOfType<ShowTextButton2>(); 
		 textButtonBuilding  = GameObject.FindObjectOfType<ShowTextButtonBuilding>(); 
		 textButtonFloor  = GameObject.FindObjectOfType<ShowTextButtonFloor>(); 


	 }
	 
	private void Update()
{	
	if(Input.GetMouseButtonDown (0)) // If you press left click.
	{
		 toMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get position of mouse
		 hit = Physics2D.Raycast(toMouse, Vector2.zero); // Vector2.zero is shorthand for writing Vector2(0,0).
		if (hit.collider != null) // if Raycast did find something, continue.
		{
			{
				if (hit.collider.CompareTag("Player") && (hit.collider != null)) // if Raycast finds "Player tag and is not null, continue.
				{
					if(!showTextPlayer)
					{
						showTextPlayer = true;
					}
						// Check if other textboxes are open. If they are, close them.
					 if ((textButton2.showTextPlayer2 == true) && (Input.GetMouseButtonDown (0)) 
						 || (textButtonBuilding.showTextPlayerBuilding == true) && (Input.GetMouseButtonDown (0))
						 || (textButtonFloor.showTextPlayerFloor == true) && (Input.GetMouseButtonDown (0)))
					 {
						 textButton2.showTextPlayer2 = false;
						 textButtonBuilding.showTextPlayerBuilding = false;
						 textButtonFloor.showTextPlayerFloor = false;
					 }   
				}
			}
		}
	}	
}
     private void OnGUI() // The on screen GUI 
     {
		 // If you've clicked the object, show this button
		  if(showTextPlayer)
		 {
			   GUI.Label(new Rect(0, 0, 100, 20), "Player:");
			   GUI.Label(new Rect(0, 20, 100, 20), "Enter Velocity:");
			   velocityString = GUI.TextField(new Rect(0, 40, 100, 20), velocityString, 20); 
			   string replaceVelocity = Regex.Replace(velocityString, "[^0-9.+-]", "");
			   stats.updateVelocity(replaceVelocity);
			   
			   GUI.Label(new Rect(0, 60, 100, 20), "Enter Mass:");
			   massString = GUI.TextField(new Rect(0, 80, 100, 20), massString, 20); 
			   string replaceMass = Regex.Replace(massString, "[^0-9.+-]", "");
			   stats.updateMass(replaceMass);
			    
				if(Input.GetMouseButton (1)) // If you press right click, close textbox
				 {
					 showTextPlayer = false;
				 }
		 }
     }
}