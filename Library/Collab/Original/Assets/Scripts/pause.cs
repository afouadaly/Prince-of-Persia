using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {
	// Use this for initialization

	public GameObject pausedMenu;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void resume(){ 
		
		//car.isPaused = false;
		pausedMenu.SetActive (false);
	}

	public void restart(){
		//car.isPaused = false;
//		Application.LoadLevel (1);
	}

	public void Quit(){
		
//		Application.Quit;
	}


}
