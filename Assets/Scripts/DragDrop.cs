using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{

    private bool isDragging;
	private BoxCollider2D coll;
	private Rigidbody2D rb;
    private Vector2 mousePosition;
	
	// object breaks if it falls off another object and is clicked. Do to rotation.

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }
	
    public void OnMouseOver()
    {
        if ((Input.GetMouseButtonDown (1)))
		{
			isDragging = true;
			coll.enabled = false;
			rb.bodyType = RigidbodyType2D.Kinematic;
			rb.freezeRotation = true; // Fixes bug of object breaking by preventing rotation.
		}   
    }

    void Update()
    {
        if (isDragging) 
		{
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
			gameObject.GetComponent<changeColors >().enabled = false;
        }
		if ((Input.GetMouseButtonDown (0)))
		{
			coll.enabled = true;
			isDragging = false;
			gameObject.GetComponent<changeColors >().enabled = true;
			rb.bodyType = RigidbodyType2D.Dynamic;
		}   
    }
}