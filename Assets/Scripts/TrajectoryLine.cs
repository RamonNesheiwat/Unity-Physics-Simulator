using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))] // Makes sure a componet of LineRenderer is available before class is initiated.
public class TrajectoryLine : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

 
    public void RenderLine(Vector3 startLocation, Vector3 endLocation)
    {
        lineRenderer.positionCount = 2; // Same as number of positions used in LineRenderer that was placed on Player object.
		Vector3[] points = new Vector3[2]; // Vector3 array that has 2 points available in it.
		points[0] = startLocation;
		points[1] = endLocation;
		lineRenderer.SetPositions(points); // Adds in points
		
    }
	
	 public void endLine() // Makes it so the line disappears when not holding mouse
    {
        lineRenderer.positionCount = 0;
    }
}
