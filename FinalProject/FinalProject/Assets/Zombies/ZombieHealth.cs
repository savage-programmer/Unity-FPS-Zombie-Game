using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour {
	public int health = 100;
	public bool isAlive;
	void Start(){
		isAlive = true;
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Bullet") {
			health -= 50;		
		}
	}
	void Update(){
		if (health < 0) {
			
			GetComponent<ZombieAI> ().enabled = false;
			GetComponent<CapsuleCollider> ().enabled = false;
			GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
			GetComponent<Animator> ().Play ("Death");
		
		}

		if (health < 0) {
			if (isAlive == true) {
				GameObject.FindObjectOfType<PlayerHealth> ().count--;
			}
			isAlive = false;
		}




	}
}
