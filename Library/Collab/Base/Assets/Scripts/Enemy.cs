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

	// Use this for initialization

	void Start () {
		
		anim = GetComponent<Animator> ();
		audioSource = GetComponents<AudioSource>();
		Enemy_health = 30;

	}
	
	// Update is called once per frame
	void Update () {

		//audioSource [1].Play ();

		if (Enemy_health == 0) {
			anim.Play ("Dying");
			audioSource [0].Play ();
			sandOfTime.SetActive (true);
			NavMeshAgent Nav_agent = gameObject.GetComponent<NavMeshAgent>();
			Nav_agent.Stop();
		}

	}


	void OnCollisionEnter (Collision c)
	{
		if (c.gameObject.CompareTag ("Prince_weapon")) {
			if(Enemy_health > 9)
				Enemy_health = Enemy_health - 10;	
		
		}




	}



}
