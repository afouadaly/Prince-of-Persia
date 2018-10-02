using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Prince_Move : MonoBehaviour {

	public int speed = 7;
	int health = 100;
	int number_SandsOfTime = 0;
	int counter_SandsOfTime;


	float yaw = 0.0f;
	float pitch = 0.0f;
	float speedH = 2.0f;
	//float speedV = 2.0f;

	bool SandsOfTime = false;

	public Text health_text;
	public Text sand_count_text;
	public Animator anim;
	private AudioSource [] audioSource;

	public GameObject pauseMenu;

	void Start () {
		Time.timeScale = 1;
		anim = GetComponent<Animator> ();
		audioSource = GetComponents<AudioSource>();
		health_text.text = "Health:" + health;
		sand_count_text.text = "Sand of time: " + number_SandsOfTime;
	}


	void Update () {

		//audioSource[0].Play();

		transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxis ("Vertical") * Time.deltaTime * speed);

		yaw += speedH * Input.GetAxis ("Mouse X");

		//pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3 (0, yaw, 0.0f);

		//Input.GetKey (KeyCode.W)
		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			if (Input.GetKey (KeyCode.LeftShift)) { 
				transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * (speed * 2), 0, Input.GetAxis ("Vertical") * Time.deltaTime * (speed * 2));
				anim.Play ("Running");
			} else {
				anim.Play ("Walking");

			}
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown(KeyCode.LeftShift)) {
			audioSource [4].Play ();
		}

		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.W)) {
			anim.Play ("Idle");
			audioSource [4].Pause ();
		}

		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S)) {
			if (Input.GetKey (KeyCode.LeftShift)) { 
				transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * (speed * 2), 0, Input.GetAxis ("Vertical") * Time.deltaTime * (speed * 2));
				anim.Play ("Running");

			} else {
				anim.Play ("Walking");

			}
		}

		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown(KeyCode.LeftShift)) {
			audioSource [4].Play ();
		}

		if (Input.GetKeyUp (KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.D)) {
			anim.Play ("Idle");
			audioSource [4].Pause ();
		}

		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.S)) {
			if (Input.GetKey (KeyCode.LeftShift)) { 
				transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * (speed * 2), 0, Input.GetAxis ("Vertical") * Time.deltaTime * (speed * 2));
				anim.Play ("Running");
				//anim.SetTrigger("isRunning");
			} else {
				anim.Play ("Walking");
				//anim.SetTrigger("isWalking");
			}
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.S)) {
			audioSource [4].Play ();
		}

		if (Input.GetKeyUp (KeyCode.RightArrow) || Input.GetKeyUp (KeyCode.D)) {
			anim.Play ("Idle");
			audioSource [4].Pause ();
		}

		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			if (Input.GetKey (KeyCode.LeftShift)) { 
				transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * (speed * 2), 0, Input.GetAxis ("Vertical") * Time.deltaTime * (speed * 2));
				anim.Play ("Running");

				//anim.SetTrigger("isRunning");
			} else {
				anim.Play ("Walking");

				//anim.SetTrigger("isWalking");
			}
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			audioSource [4].Play ();
		}
			
		if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			anim.Play ("Idle");
			audioSource [4].Pause ();
		}

		if (Input.GetKey (KeyCode.Space)) {				
			anim.Play ("Jumping");
			transform.Translate (0, 30f * Time.deltaTime, 100f * Time.deltaTime);
			print ("Jump");
		}

		if (Input.GetKey (KeyCode.R)) {	
			
			anim.Play ("Roll");
			transform.Translate (0, 0, 100f * Time.deltaTime);
			print ("Roll");
		}


		if (Input.GetKey (KeyCode.E)) {
			
			print ("pick weapon");
			audioSource [5].Play ();
		}

		if (Input.GetKey (KeyCode.Q)) {
			if (number_SandsOfTime > 0) {
				number_SandsOfTime--;
				SandsOfTime = true;
				counter_SandsOfTime = 5;
				print ("sand of time");
			}
		}

		if (Input.GetKey (KeyCode.V)) {
			
			anim.Play ("Acro");
			Invoke ("delay", 1.0f);

		}
			

		if (Input.GetMouseButtonDown (0)) {
			anim.Play ("Standing Melee Attack Horizontal");
			print ("attack");
		}

		if (Input.GetMouseButtonDown (1)){
			anim.Play ("Sword And Shield Impact");
			print ("defense");
		}

		if (Input.GetKey (KeyCode.P) || Input.GetKey (KeyCode.Escape)) {
			
			if (Input.GetKey (KeyCode.P) || Input.GetKey (KeyCode.Escape)) {
				Time.timeScale = 0;
				pauseMenu.SetActive (true);
			}

		}

		if (health == 0) {
			audioSource[0].Play();
			anim.Play ("Dying");

		}

		if (SandsOfTime) {
			counter_SandsOfTime -= (int) Time.deltaTime;
			if (counter_SandsOfTime <= 0) 
				SandsOfTime = false;
		}


		health_text.text = "Health:" + health;
		sand_count_text.text = "Sand of time: " + number_SandsOfTime;

	}
		

	void OnCollisionEnter (Collision c)
	{
		if (c.gameObject.CompareTag ("Trap")) {
			//GameObject.Destroy (c.gameObject);
			if(health > 9){
				health = health - 10;
				print ("OnCollisionEnter");
			}
		}
		if (c.gameObject.CompareTag ("DeadlyTrap")) {
			health = 0;
			GameOver ();
		}
		if (c.gameObject.CompareTag ("SandsOfTime")) {
			number_SandsOfTime ++;
		}



	}


	void OnTriggerEnter(Collider c){
		if (c.gameObject.CompareTag ("SandsOfTime")) {
			number_SandsOfTime ++;
			Destroy(c. gameObject);
		}

		if (c.gameObject.CompareTag ("End1")) 
			Application.LoadLevel (2);		
		
		if (c.gameObject.CompareTag ("End2")) 
			Application.LoadLevel (3);
		
	
	}


	void GameOver(){


	}

	void delay() {

		transform.Translate (0, 0, 200f * Time.deltaTime);
	}



}
