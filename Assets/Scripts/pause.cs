using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pause : MonoBehaviour {
	
	public int level;
	public GameObject pausedMenu;

	void Start () {
		
		print("start");
	}

	public void resume(){ 
		
		Time.timeScale = 1;
		pausedMenu.SetActive (false);
	}

	public void restart(){
		
		Application.LoadLevel (level);
	}

	public void Quit(){
		
		Application.LoadLevel (0);
	}


}
