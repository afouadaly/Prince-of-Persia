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
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Input.GetAxis ("Horizontal")*Time.deltaTime*speed,0,Input.GetAxis ("Vertical")*Time.deltaTime*speed);

		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		//Input.GetKey (KeyCode.W)
		if (Input.GetKey (KeyCode.LeftShift)) 
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * (speed*2), 0, Input.GetAxis ("Vertical") * Time.deltaTime * (speed*2));
		
		if (Input.GetKey (KeyCode.R)) {
			transform.Translate (0,0,0.5f);
			print ("Roll");
		}
		if (Input.GetKey (KeyCode.E))
			print("pick weapon");

		if (Input.GetKey (KeyCode.Q))
			print("sand of time");
		if (Input.GetKey (KeyCode.R))
			print("Roll");

		if(Input.GetMouseButtonDown(0)) 
			print("attack");
		if(Input.GetMouseButtonDown(1)) 
			print("defense");

		if (Input.GetKey (KeyCode.P) || Input.GetKey (KeyCode.Escape))
			print("pause");
		

	}
}
