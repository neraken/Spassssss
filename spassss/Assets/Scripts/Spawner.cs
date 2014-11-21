using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject engines_enemy;
	private GameObject[] spawners;
	private List <GameObject> UFOs;
	// Use this for initialization
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag ("Spawn");
		InvokeRepeating ("Spawn",1,1);
		UFOs = new List<GameObject> ();
	}
	
	// Update is called once per frame
	void Spawn(){
		GameObject spawn = spawners [Random.Range (0, spawners.Length)];
		GameObject clone = Instantiate (engines_enemy, spawn.transform.position, Quaternion.identity) as GameObject;
		clone.name = "UFO - " + Time.time.ToString ();
		UFOs.Add (clone);
		}
}
