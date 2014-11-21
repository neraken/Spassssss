using UnityEngine;
using System.Collections;


public class PlayerController2D : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	public int power=10;
	public GameObject shot;
	public GameObject bomb;
	public Transform shotSpawn;
	public Transform LshotSpawn;
	public float fireRate;
	
	
	private GameController gameController;
	
	private float nextFire;
	
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	
	void Update ()
	{
//		if (Input.GetButton("Fire1") && Time.time > nextFire)
//		{
//			nextFire = Time.time + fireRate;
//			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
//			Instantiate(shot,LshotSpawn.position,shotSpawn.rotation);
//			audio.Play ();
//		}
//		if (Input.GetButton ("Bomb")) {
//			Instantiate(bomb);
//			
//			gameController.bombUsed();
//		}
//		if (Input.GetButton ("Ability")) {
//			gameController.abilityUsed();
//		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		if (Input.GetButton ("Fire2")) {
			speed = 10;
			
		}
		
		Vector3 movement = new Vector3 (moveHorizontal,moveVertical, 0.0f );
		gameObject.transform.Translate( movement * speed * Time.deltaTime);

	}

}