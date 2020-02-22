using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {
	public List<GameObject> weapons;
	public int selectedIndex;
	// Use this for initialization
	void Start () {
		Switch (0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			if (selectedIndex >= weapons.Count -1) {
				selectedIndex = 0;
			} else {
				selectedIndex++;
			}
			Switch (selectedIndex);
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (selectedIndex <= 0) {
				selectedIndex = weapons.Count - 1;
			} else {
				selectedIndex--;
			}
			Switch (selectedIndex);
		}
	}
	void Switch(int index){
		foreach (GameObject obj in weapons) {
			obj.SetActive (false);
		}
		weapons [index].SetActive (true);
	}
}
