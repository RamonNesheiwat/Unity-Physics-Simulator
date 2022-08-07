/*
* When mass slider changes value, changes value for mass' rigid body
* Only used when in 'Real Spring' mode
*
* @BeauRichter
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeMass : MonoBehaviour
{

	public GameObject massSpring;
	
    public void valueChange(float val) {
    	
    	massSpring.GetComponent<Rigidbody2D>().mass = val;
    }  
}

