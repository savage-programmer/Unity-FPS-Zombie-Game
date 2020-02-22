using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float speed = 0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		 
		if (Input.GetKey(KeyCode.UpArrow)) {
			transform.position += new Vector3 (0, 0, 10) * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			transform.position += new Vector3 (0, 0, -10) * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.position += new Vector3 (10, 0, 0) * Time.deltaTime * speed;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-10, 0, 0) * Time.deltaTime * speed;
		}

	}
}
