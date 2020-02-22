using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour {
	public int health = 100;
	public bool isAlive;
	public Text healthBar;
	public GameObject gameOverObject;
	public GameObject bloodScreen;
	public GameObject gameWinObject;
	public int count;
	public Text score;
	// Use this for initialization
	void Start () {
		isAlive = true;
		gameOverObject.SetActive (false);
		gameWinObject.SetActive (false);
		bloodScreen.SetActive (false);
		count = 10;
		score.text = "Zombie Killed " + count;
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 0 || count == 0) {
			if (isAlive == true) {
				if (count == 0) {
					gameWinObject.SetActive (true);
				}
				StartCoroutine ("GameOver");
				
			}
			isAlive = false;
		}

		healthBar.text = "Your Health " + health;

		if (bloodScreen.GetComponent<RawImage> ().color.a < 0.1f) {
			bloodScreen.SetActive (false);
		}
		score.text = "Zombie Killed " + count;
	
	}


	public void GetDamage(int damage){
		health -= damage;
		bloodScreen.SetActive (true);
	}

	IEnumerator GameOver()
	{
		gameOverObject.SetActive (true);
		GetComponent<FirstPersonController> ().enabled = false;
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene("MainMenu");

	}
}
