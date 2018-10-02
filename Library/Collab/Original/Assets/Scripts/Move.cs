using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	public int speed = 1;
	float yaw = 0.0f;
	float pitch = 0.0f;
	float speedH = 2.0f;
	float speedV = 2.0f;
	int health = 100;
	int count = 0;

	public Animator anim;

	void Start () {

		anim = GetComponent<Animator> ();
	}


	void Update () {
		
		transform.Translate (Input.GetAxis ("Horizontal")*Time.deltaTime*speed,0,Input.GetAxis ("Vertical")*Time.deltaTime*speed);

		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			if (Input.GetKey (KeyCode.LeftShift)) { 
				transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * (speed * 2), 0, Input.GetAxis ("Vertical") * Time.deltaTime * (speed * 2));
				anim.Play ("Running");
			} else {
				anim.Play ("Walking");
			}
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) {
			anim.Play ("Idle");
		}
			
//		if (Input.GetKey (KeyCode.LeftShift)) { 
//			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * (speed * 2), 0, Input.GetAxis ("Vertical") * Time.deltaTime * (speed * 2));
//			anim.Play ("Running");
//		}

		if (Input.GetKey (KeyCode.Space)) {				
			anim.Play ("Jumping");
		}

		if (Input.GetKey (KeyCode.R)) {	
			anim.Play ("Dive Roll");
			transform.Translate (0,0,0.5f);
			print ("Roll");
		}
		if (Input.GetKey (KeyCode.E))
			print("pick weapon");

		if (Input.GetKey (KeyCode.Q))
			print("sand of time");
		
		if (Input.GetMouseButtonDown (0)) { 
			anim.Play ("Standing Melee Attack Horizontal");
			print("attack");
		}
		
		if(Input.GetMouseButtonDown(1)) 
			print("defense");

		if (Input.GetKey (KeyCode.P) || Input.GetKey (KeyCode.Escape))
			print("pause");
		

	}
}
