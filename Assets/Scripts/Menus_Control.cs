using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus_Control : MonoBehaviour {
	public GameObject title;
	public GameObject options;
	public GameObject crd;
	public GameObject htp;
	public GameObject audio;
	public static bool mute = false;
	public Slider MLS;
	public Slider SLS;
	public Slider ELS;
	// Use this for initialization
	void Start () {
		title.SetActive (true);
		options.SetActive(false);
		htp.SetActive (false);
		crd.SetActive (false);
		audio.SetActive (false);

		MLS.onValueChanged.AddListener (delegate {
			MusicLevel ();
		});

		SLS.onValueChanged.AddListener (delegate {
			MusicLevel ();
		});

		ELS.onValueChanged.AddListener (delegate {
			MusicLevel ();
		});

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void startGame(){
		Application.LoadLevel (1);

	}
	public void getOptions(){
		title.SetActive(false);
		options.SetActive(true);
	}
	public void muteSound(bool v){
		if (v = true) 
			mute = true;
		else 
			mute = true;
		
	}

	public void howToPlay(){
		options.SetActive(false);
		htp.SetActive (true);
	}
	public void credits(){
		options.SetActive(false);
		crd.SetActive (true);
	}

	public void Quit(){
		Application.Quit();
	}
	public void Backtitle(){
		options.SetActive(false);
		title.SetActive (true);
	}
	public void Audio(){
		options.SetActive(false);
		audio.SetActive (true);
	}

	public void Backoptions(){
		htp.SetActive (false);
		crd.SetActive (false);
		options.SetActive(true);
	}
	public void MusicLevel(){
		float MusicLevel = MLS.value;  
		print (MusicLevel);
	}

	public void SpeechLevel(){
		float SpeechLevel = SLS.value;  
		print (SpeechLevel);
	}
	public void EffectLevel(){
		float EffectLevel = ELS.value;  
		print (EffectLevel);
	}

}
