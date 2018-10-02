﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;



public class Boss_Move : MonoBehaviour {

	public Animator anim;
	public int boss_health;
	//public GameObject canvas_credits;
	private AudioSource [] audioSource;


	public static int health = 200;
	public Text Boss_health_text;


	void Start () {
		
		anim = GetComponent<Animator> ();	
		audioSource = GetComponents<AudioSource>();
		Boss_health_text.text = "Boss health:" + health;
		anim.Play ("Walking");
	}
	
	// Update is called once per frame
	void Update () {

		print (" " + health);

		if (health <= 0) {
			anim.Play ("Dying");

			NavMeshAgent Nav_agent = gameObject.GetComponent<NavMeshAgent>();
			Nav_agent.Stop();

			Application.LoadLevel (5);

			}

		if (Prince_Move.health<= 0) {
			anim.Play ("Idle");

			NavMeshAgent Nav_agent = gameObject.GetComponent<NavMeshAgent>();
			Nav_agent.Stop();
		}

		anim.SetInteger ("boss_health", health);

		Boss_health_text.text = "Boss health:" + health;

		} 
				

	void OnCollisionEnter (Collision c){
		
	}


	void OnTriggerEnter(Collider c){
	
		if (c.gameObject.CompareTag ("Prince_weapon")) {
			print ("Oncollider_princeee");

			if (health > 9) {
				health = health - 10;	
			}
		}

	}
		




}
