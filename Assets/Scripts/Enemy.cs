using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Enemy : MonoBehaviour {

	public Animator anim;
	public static int Enemy_health;
	public bool isWalking;
	public GameObject sandOfTime;
	private AudioSource [] audioSource;
	public GameObject weapon;

	float AttackDistance = 10;
	public GameObject target;

	bool dead;


	void Start () {
		
		anim = GetComponent<Animator> ();
		audioSource = GetComponents<AudioSource>();
		Enemy_health = 30;
		dead = false;

	}
	

	void Update () {

		if (!dead) {
			
			if (Enemy_health == 0){
				
				audioSource [2].Pause ();
				sandOfTime.SetActive (true);
				NavMeshAgent Nav_agent = gameObject.GetComponent<NavMeshAgent> ();
				Nav_agent.Stop ();
				dead = true;
				weapon.SetActive (false);


			}
		}

		if (Vector3.Distance (transform.position, target.transform.position) < 2f) {
			print ("Enemy_Attack");

			}

		
	}
		
	void OnTriggerEnter(Collider c){

		if (c.gameObject.CompareTag ("Prince_weapon")) {
			
			if (Enemy_health > 9) {
				audioSource [0].Play ();
				Enemy_health = Enemy_health - 10;	
				print ("Enemy health" + Enemy_health);
			}
		}
	}

	/*
	void OnCollisionEnter (Collision c){
		if (c.gameObject.CompareTag ("Prince_weapon")) {
			if(Enemy_health > 9)
				Enemy_health = Enemy_health - 10;	


		}
	}*/
}
