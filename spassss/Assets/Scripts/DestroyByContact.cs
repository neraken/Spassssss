using UnityEngine;
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