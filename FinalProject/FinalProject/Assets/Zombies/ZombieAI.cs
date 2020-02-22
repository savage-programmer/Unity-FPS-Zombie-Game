using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class ZombieAI : MonoBehaviour
{
	public enum ZombieState
	{
		Idle,
		Chase,
		Attack
	}
	
	public bool isAlive;
	private bool chase;
	private bool attack;
	private bool idle;
	
	public ZombieState currentState;
	
	public GameObject target;
	public float distanceToChase;
	public float distanceToAttack;
	
	public Animator animator;
	public NavMeshAgent agent;

	public int health;
	public GameObject bloodEffect;

	public List<AudioClip> audioClips;
	public AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
		health = 100;
        isAlive = true;
		source = GetComponent<AudioSource> ();
		target = GameObject.FindObjectOfType<PlayerHealth> ().gameObject;

	}

    // Update is called once per frame
    void Update()
    {
		if(isAlive)
		{
			SetStates();
			UpdateAnimator();
			
			if(currentState == ZombieState.Idle)
			{
				Idle();
			}
			if(currentState == ZombieState.Chase)
			{
				Chase();
			}
			if(currentState == ZombieState.Attack)
			{
				Attack();
			}
		}



    }

	
	void SetStates()
	{
		if(Vector3.Distance(transform.position, target.transform.position) > distanceToChase)
		{
			currentState = ZombieState.Idle;
		}
		else if(Vector3.Distance(transform.position, target.transform.position) > distanceToAttack)
		{
			currentState = ZombieState.Chase;
		}
		else if(Vector3.Distance(transform.position, target.transform.position) < distanceToAttack)
		{
			currentState = ZombieState.Attack;
		}
	}
	
	void UpdateAnimator()
	{
		animator.SetBool("chase", chase);
		animator.SetBool("attack", attack);
	}
	
	void Idle()
	{
		chase = false;
		attack = false;

		agent.speed = 0;
	}
	
	void Chase()
	{
		
		attack = false;
		chase = true;
		agent.SetDestination(target.transform.position);
		agent.speed = 3f;
	}
	
	void Attack()
	{
		
		chase = false;
		attack = true;
		agent.SetDestination(target.transform.position);
		Vector3 lookAtPosition = new Vector3 (target.transform.position.x,transform.position.y,target.transform.position.z);

		this.transform.LookAt (lookAtPosition);
		agent.speed = 0f;
	}
	public void ApplyDamage(int damage)
	{
		target.transform.GetComponent<PlayerHealth> ().GetDamage (damage);
	}

	public void GetDamage(int damage){
		health -= damage;
	}

	public void PlayAudio(int clipIndex)
	{
		source.clip = audioClips [clipIndex];
		source.Play ();
	}
}
