using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	private bool fire;
	public int totalBullets;
	public int remainingBullets;
	public int magLimit;
	public bool isReloading;
	
	public GameObject bullet;
	public float bulletSpeed;
	public GameObject shootPoint;
	public float bulletDestroyTime;
	public AudioClip fireSound;
	public AudioClip ReloadSound; 
	private AudioSource source;
	
	public Animator animator;


	public UnityEngine.UI.Text bulletsInfo;
	public int bulletsToShow;
	
    // Start is called before the first frame update
    void Start()
    {
        remainingBullets = magLimit;
		source = GetComponent<AudioSource> ();
		bulletsToShow = totalBullets;
    }

    // Update is called once per frame
    void Update()
    {
		fire = Input.GetButtonDown("Fire1");
		
		if(totalBullets > 0)
		{
			if(remainingBullets > 0)
			{
				if(fire)
				{
					Fire();
				}	
			}	
			else if(!isReloading)
			{
				StartCoroutine(Reload() );

			}
		}
		
		bulletsInfo.text = "Remaining Bullets " + bulletsToShow;
    }
	
	void Fire()
	{
		GameObject b = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
		
		b.GetComponent<Rigidbody>().AddForce(shootPoint.transform.forward * bulletSpeed, ForceMode.Impulse);
		Destroy(b, bulletDestroyTime);
		
		remainingBullets--;
		bulletsToShow--;
		animator.Play("Fire");
		source.clip = fireSound;
		source.Play ();
	}
	IEnumerator Reload()
	{
		isReloading = true;
		animator.Play("Reload");
		source.clip = ReloadSound;
		source.Play ();

		yield return new WaitForSeconds (2);
		CalculateBullets ();
		isReloading = false;

	}

	public void CalculateBullets()
	{
		print ("dfsd");
		if(totalBullets > magLimit)
		{
			remainingBullets = magLimit;
			totalBullets -= magLimit;
		}
		if(totalBullets < magLimit)
		{
			int limit = totalBullets;
			remainingBullets = limit;
			totalBullets = 0;
		}
	}
}
