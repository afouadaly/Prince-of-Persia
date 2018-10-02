using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour {

	public Transform player;
	static Animator anim;
	private AudioSource [] audioSource;

	void Start () {

		anim = GetComponent<Animator> ();
		audioSource = GetComponents<AudioSource>();

	}
	

	void Update () {

		if (Vector3.Distance (player.position, this.transform.position) < 20) {
			Vector3 direction = player.position - this.transform.position;
			direction.y = 0;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			anim.SetBool ("isIdle", false);
			audioSource [3].Play ();

			if (direction.magnitude > 5) {

				this.transform.Translate (0, 0, 0.05f);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);

			} else {

				anim.SetBool ("isWalking", false);
				anim.SetBool ("isAttacking", true);
			}		
		} else {

			anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);
		}
}
}
