using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandIK : MonoBehaviour {
	private Animator animator;

	public Transform targetnew;
	private Transform LeftTarget;
	private Transform RightTarget;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {


		WeaponIKHandler IKHandler = GameObject.FindObjectOfType<WeaponIKHandler> ();
		if (IKHandler != null) {
			LeftTarget = IKHandler.LeftIK;
			RightTarget = IKHandler.RightIK;
		} else {
			LeftTarget = null;
			RightTarget = null;
		}


	}

	void LateUpdate()
	{
		if(LeftTarget != null){
			animator.GetBoneTransform (HumanBodyBones.LeftHand).position = LeftTarget.position;
		}
		if(RightTarget != null){
			animator.GetBoneTransform (HumanBodyBones.RightHand).position = RightTarget.position;
		}
	}
	void OnAnimatorIK(int layer){
		
		if (LeftTarget != null) {
			animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1);
			animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1);
			animator.SetIKPosition (AvatarIKGoal.LeftHand, LeftTarget.position);
			animator.SetIKRotation (AvatarIKGoal.LeftHand, LeftTarget.rotation);
		}
		if (RightTarget != null) {
			animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);
			animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);
			animator.SetIKPosition (AvatarIKGoal.RightHand, RightTarget.position);
			animator.SetIKRotation (AvatarIKGoal.RightHand, RightTarget.rotation);
		}
	}

}
