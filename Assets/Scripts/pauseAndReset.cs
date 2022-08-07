using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 using UnityEngine.UI;  

public class pauseAndReset : MonoBehaviour
{
	// Can't be in textbox while pausing or reseting.
	void Update()
 {
     if (Input.GetKeyDown(KeyCode.P))
     {
         if (Time.timeScale == 1)
             Time.timeScale = 0;
         else
             Time.timeScale = 1;
     }
	  if (Input.GetKeyDown(KeyCode.R))
	  {
		  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		  Time.timeScale = 1;
	  }
		  
 }
  
}

