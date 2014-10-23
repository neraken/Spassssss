using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
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
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			Instantiate(shot,LshotSpawn.position,shotSpawn.rotation);
			audio.Play ();
		}
		if (Input.GetKeyDown (KeyCode.B)) {

			gameController.bombUsed();
				}
		if (Input.GetButton ("Ability")) {
			gameController.abilityUsed();
				}
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (Input.GetButton ("Fire2")) {
						speed = 3;

				} else {
			speed = 10;
				}
		
		Vector3 movement = new Vector3 (moveHorizontal, moveVertical,0.0f);
		rigidbody.velocity = movement * speed;

		rigidbody.position = new Vector3 
			(
				Mathf.Clamp (rigidbody.position.x, boundary.xMin, boundary.xMax), 
				
				Mathf.Clamp (rigidbody.position.y, boundary.yMin, boundary.yMax),0.0f
				);
		
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	}
}