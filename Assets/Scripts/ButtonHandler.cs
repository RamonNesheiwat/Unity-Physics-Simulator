using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
	public string theForce;
	public GameObject inputField;
	public GameObject textDisplay;

	
    // Start is called before the first frame update
    public void SetForce(string text)
	{
		theForce = inputField.GetComponent<Text>().text;
		textDisplay.GetComponent<Text>().text = "Welcome" + theForce + " to game";
		//Text txt = transform.Find("Text").GetComponent<Text>();
		//txt.text = text;
	}
    
}
 