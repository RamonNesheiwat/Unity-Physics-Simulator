using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  

public class clickStuff : MonoBehaviour
{
public GameObject Player; // Test class for calling other classes. Could be used in the future.

void Start()
{
	Player = GameObject.FindGameObjectWithTag("Player"); 
}
void Update()
{	
	if(Input.GetMouseButtonDown (1))
	{
		Debug.Log("Mouse2 pressed");
		Vector2 toMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(toMouse, Vector2.zero);
		if (hit.collider != null)
		{
			//Debug.Log( hit.collider.name + "    " + hit.point);
			ShowTextButton text = hit.collider.GetComponent<ShowTextButton>(); 
			//if(hit.collider.gameObject.tag == "Player")
				//if(text)
			{
				if (hit.collider.CompareTag("Player") && (hit.collider != null))
				{
				Debug.Log("OK");
				}
			}
			 
		}
		else
		{
			Debug.Log("clicked on empty space" );
		}		
	}
}
}