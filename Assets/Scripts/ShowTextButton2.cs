using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;



class ShowTextButton2 : MonoBehaviour
 {
	 public  bool showTextPlayer2 = false;
	 private string velocityString2 = "";
	 private velocityHandler vel2;
	 private string massString2 = "";
	 private Vector2 toMouse;
	 private RaycastHit2D hit;
	 public Player2Stats stats2;
	 public ShowTextButton textButton;
	 public ShowTextButtonBuilding textButtonBuilding;
     public ShowTextButtonFloor textButtonFloor;

	 
	private void Start()
	 {
		stats2  = GameObject.FindObjectOfType<Player2Stats>();
		textButton  = GameObject.FindObjectOfType<ShowTextButton>(); 
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
			if (hit.collider.CompareTag("Player2") && (hit.collider != null)) // if Raycast finds "Player2 tag and is not null, continue.
			{
					if(!showTextPlayer2)
					{
						showTextPlayer2 = true;
					}
					// If other texboxes are open, close them.
					 if ((textButton.showTextPlayer == true) && (Input.GetMouseButtonDown (0)) 
						 || (textButtonBuilding.showTextPlayerBuilding == true) && (Input.GetMouseButtonDown (0))
						 || (textButtonFloor.showTextPlayerFloor == true) && (Input.GetMouseButtonDown (0)))
					 {
						 textButton.showTextPlayer = false;
						 textButtonBuilding.showTextPlayerBuilding = false;
						 textButtonFloor.showTextPlayerFloor = false;	 
					 }   
			}
		}
	}	
}
     private void OnGUI() // The on screen GUI 
     {
		 // If you've clicked the object, show this button
		  if(showTextPlayer2)
		 {
			   GUI.Label(new Rect(0, 60, 100, 20), "Enter Mass:");
			   massString2 = GUI.TextField(new Rect(0, 80, 100, 20), massString2, 20); 
			   string replaceMass2 = Regex.Replace(massString2, "[^0-9.+-]", "");
			   stats2.updateMass2(replaceMass2);
			   
			   GUI.Label(new Rect(0, 0, 100, 20), "Player2:");
			   GUI.Label(new Rect(0, 20, 100, 20), "Enter Velocity:");
			   velocityString2 = GUI.TextField(new Rect(0, 40, 100, 20), velocityString2, 20); 
			   string replaceVelocity2 = Regex.Replace(velocityString2, "[^0-9.+-]", "");
			   stats2.updateVelocity2(replaceVelocity2);
			    
				 if(Input.GetMouseButton (1)) // If you press right click, close textbox
				 {
					 showTextPlayer2 = false;
				 }
		 }
     }
}