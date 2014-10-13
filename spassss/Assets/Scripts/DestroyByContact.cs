/*using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;
	public int teamID=0;
	
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
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}

		destroyableActor foo = other.gameObject.GetComponent<destroyableActor> ();
		
		DestroyByContact foo2 = other.gameObject.GetComponent<DestroyByContact> ();
		if(teamID != foo2.teamID){
		foo.doDmg (5);
		}
				Instantiate(explosion, transform.position, transform.rotation);
			

		//Time.deltaTime;  //comes in seconds

		if (other.tag == "Player")
		{
			gameController.astroidHealth -=10;
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();

		}
		Destroy(other.gameObject);
		Destroy(gameObject);
		gameController.AddScore (scoreValue);
	}
}
*/
using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	
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
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.tag == "Boundary")
		{
			return;
		}
		//Instantiate(explosion, transform.position, transform.rotation);
		if (other.tag == "Player") {
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
			Destroy(other.gameObject);
		}
		else if (gameObject.tag == "PlayerBullet" && other.tag == "Player") {
			Debug.Log ("no friendly fire1");		
		} else if (gameObject.tag == "Enemy" && other.tag == "Enemy") {
			Debug.Log ("no friendly fire2");			
		} else if(gameObject.tag == "Enemy" && other.tag == "Player"){
			Instantiate(explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		} else if(gameObject.tag == "Enemy" && other.tag == "PlayerBullet"){
			Instantiate(explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
}
}