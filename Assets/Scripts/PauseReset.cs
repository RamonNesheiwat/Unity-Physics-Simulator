/*
* Initial script used to pause and reset the scenes, 
* a new script written by Ramon improved upon the idea 
* having the functions keybound instead of using buttons
*
* @Beau Richter
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseReset : MonoBehaviour
{

    int a = 0;
	
    public void resetGame() {
	
	SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void pause() {


		if (a == 0) {
			GameObject.Find("Pause").GetComponentInChildren<Text>().text = "Start";
			Time.timeScale = 0;
			a = 1;
		} else {
			GameObject.Find("Pause").GetComponentInChildren<Text>().text = "Stop";
			Time.timeScale = 1;
			a = 0;
		}
    }
}
