/*
* Script being used to draw a line between the fixed point and hanging mass
* using a stretched sprite to give the image of an oscillating spring
*
* @Beau Richter
*/

 using UnityEngine;
 using System.Collections;
 
 public class DrawLine : MonoBehaviour {
    
     public GameObject[] targets;
     public Material mat;

     // Use this for initialization
     private LineRenderer spring;
     void Start () {
        // assign material and initial points
         spring = this.GetComponent<LineRenderer>();
         spring.material = mat;
         Vector2 p1 = targets [0].transform.position;
         Vector2 p2 = targets[1].transform.position;
         spring.SetPosition (0, p1);
         spring.SetPosition(1, p2);
    }
     
     // Update is called once per frame, assigns new points and draws new line
     void FixedUpdate () {
         Vector2 p1 = targets [0].transform.position;
         Vector2 p2 = targets [1].transform.position;
         Vector2 lineVector = p2 - p1;
         spring.SetPosition (0, p1);
         spring.SetPosition (1, p2);
     }
 }