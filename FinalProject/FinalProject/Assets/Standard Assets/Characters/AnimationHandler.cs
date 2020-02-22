using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class AnimationHandler : MonoBehaviour {
	public Animator animator;
	private FirstPersonController fps;

	// Use this for initialization
	void Start () {
		fps = GetComponent<FirstPersonController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (fps.m_IsWalking) {
			animator.SetFloat ("Vertical", fps.m_Input.y,0.3f,Time.deltaTime);
			animator.SetFloat ("Horizontal", fps.m_Input.x,0.3f,Time.deltaTime);
		}
	}
}
