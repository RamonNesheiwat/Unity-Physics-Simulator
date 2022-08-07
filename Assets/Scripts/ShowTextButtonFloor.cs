using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;



class ShowTextButtonFloor : MonoBehaviour
 {
	 public bool showTextPlayerFloor = false;
	 private string frictionString = "";
	 private Vector2 toMouse;
	 private RaycastHit2D hit;
	 public FloorStats stats;
	 public ShowTextButton2 textButton2;
	 public ShowTextButtonBuilding textButtonBuilding;
	 public ShowTextButton textButton;


	 
	private void Start()
	 {
		 stats  = GameObject.FindObjectOfType<FloorStats>(); 
		 textButton2  = GameObject.FindObjectOfType<ShowTextButton2>(); 
		 textButton  = GameObject.FindObjectOfType<ShowTextButton>(); 
		 textButtonBuilding  = GameObject.FindObjectOfType<ShowTextButtonBuilding>(); 
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
				if (hit.collider.CompareTag("Floor") && (hit.collider != null)) // if Raycast finds "Floor tag and is not null, continue.
				{
					if(!showTextPlayerFloor)
					{
						showTextPlayerFloor = true;
					}
					// If other texboxes are open, close them.
					 if ((textButton2.showTextPlayer2 == true) && (Input.GetMouseButtonDown (0)) 
						 || (textButtonBuilding.showTextPlayerBuilding == true) && (Input.GetMouseButtonDown (0))
					     ||  ((textButton2.showTextPlayer2 == true) && (Input.GetMouseButtonDown (0)) 
						 || (textButton.showTextPlayer == true) && (Input.GetMouseButtonDown (0))))
					 {
						 textButton2.showTextPlayer2 = false;
						 textButtonBuilding.showTextPlayerBuilding = false;
						 textButton.showTextPlayer = false;						 
					 }   
				}
			}
		}
	}	
}
     private void OnGUI() // The on screen GUI 
     {
		 // If you've clicked the object, show this button
		  if(showTextPlayerFloor)
		 {
			   GUI.Label(new Rect(0, 0, 100, 20), "Floor:");
			   GUI.Label(new Rect(0, 20, 100, 20), "Enter Friction:");
			   frictionString = GUI.TextField(new Rect(0, 40, 100, 20), frictionString, 20); 
			   string replaceFriction = Regex.Replace(frictionString, "[^0-9.+-]", "");
			   stats.updateFriction(replaceFriction);
			   
			    
				if(Input.GetMouseButton (1)) // If you press right click, close textbox.
				 {
					 showTextPlayerFloor = false;
				 }
		 }
     }
}