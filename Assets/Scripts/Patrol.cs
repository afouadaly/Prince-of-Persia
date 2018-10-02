// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour {

	public Transform[] points;
	public bool isWalking = false;
	private int destPoint = 0;
	private NavMeshAgent agent;
	public Animator anim;
	public GameObject target;
	private AudioSource [] audioSource;

	void Start () {
		
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator> ();
		audioSource = GetComponents<AudioSource>();
		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).

		agent.autoBraking = false;

		GotoNextPoint();
	}


	void GotoNextPoint() {
		// Returns if no points have been set up
		if (points.Length == 0)
			return;


		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;
	}


	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.

		if (Enemy.Enemy_health > 0) {

			if (!agent.pathPending && agent.remainingDistance < 0.5f) {
				audioSource [2].Play ();
				anim.SetBool ("isWalking", true);
				GotoNextPoint ();
			}

			if (!agent.pathPending && agent.remainingDistance > 0.5f) {
				//anim.Play ("Walking");
			}

			if (Vector3.Distance (transform.position, target.transform.position) < 6f) {
				print ("Running");
				audioSource [1].Play ();
				//anim.Play ("Running");
			}

			if (Vector3.Distance (transform.position, target.transform.position) < 2f) {
				print ("Enemy_Attack");
				anim.Play ("Stabbing");
			}




		}
		else {
			anim.Play ("Dying");
			//audioSource [0].Play ();
		}

	
	}







}