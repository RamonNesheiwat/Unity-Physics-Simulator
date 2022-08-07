using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  
using System.Text.RegularExpressions;
using UnityEngine.EventSystems;



class ShowTextButtonBuilding : MonoBehaviour
 {
	 public bool showTextPlayerBuilding = false;
	 private string massString = "";
	 private Vector2 toMouse;
	 private RaycastHit2D hit;
	 public TallBuildingStats stats;
	 public ShowTextButton2 textButton2;
	 public ShowTextButton textButton;
	 public ShowTextButtonFloor textButtonFloor;

	 
	private void Start()
	 {
		 stats  = GameObject.FindObjectOfType<TallBuildingStats>(); 
		 textButton2  = GameObject.FindObjectOfType<ShowTextButton2>(); 
		 textButton  = GameObject.FindObjectOfType<ShowTextButton>(); 
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
				if (hit.collider.CompareTag("TallBuilding") && (hit.collider != null)) // if Raycast finds "TallBuilding tag and is not null, continue.
				{
					if(!showTextPlayerBuilding)
					{
						showTextPlayerBuilding = true;
					}
						// If other texboxes are open, close them.
					 if ((textButton2.showTextPlayer2 == true) && (Input.GetMouseButtonDown (0)) 
						 || (textButton.showTextPlayer == true) && (Input.GetMouseButtonDown (0))
					 	 || (textButtonFloor.showTextPlayerFloor == true) && (Input.GetMouseButtonDown (0)))
					 {
						 textButton2.showTextPlayer2 = false;
						 textButton.showTextPlayer = false;
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
		  if(showTextPlayerBuilding)
		 {   
			   GUI.Label(new Rect(0, 0, 100, 20), "Building:");
			   GUI.Label(new Rect(0, 20, 100, 20), "Enter Mass:");
			   massString = GUI.TextField(new Rect(0, 40, 100, 20), massString, 20); 
			   string replaceMass = Regex.Replace(massString, "[^0-9.+-]", "");
			   stats.updateMass(replaceMass);
			    
				if(Input.GetMouseButton (1)) // If you press right click, close textbobx.
				 {
					 showTextPlayerBuilding = false;
				 }
		 }
     }
}