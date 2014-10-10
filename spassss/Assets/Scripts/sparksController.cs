using UnityEngine;
using System.Collections;


public class sparksController : MonoBehaviour {

	private ParticleSystem[] sparks;
	// Use this for initialization
	void Start () {
		sparks = GetComponents <ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * 100 * Time.deltaTime);
		if (Input.GetKeyDown (KeyCode.E)) {
			foreach(ParticleSystem engines_enemy in sparks){
				engines_enemy.Pause();
				engines_enemy.Emit (100);
			}
		}
	}
}
