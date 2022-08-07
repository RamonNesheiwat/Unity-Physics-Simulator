using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class forceHandler : MonoBehaviour
{

    public void Start()
    {
		// Get position of MousePointA Object.
		 transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public void Update()
    {
		//  Get position of mouse and world position.
	 Vector2 position = Camera.main.ScreenToWorldPoint (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
	 // Replace positions from Start() with Positions of Vector2 position.
	 transform.position = new Vector3(position.x, position.y, -1);	
    }
}
