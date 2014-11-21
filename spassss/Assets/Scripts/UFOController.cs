using UnityEngine;
using System.Collections;

public class UFOController : MonoBehaviour {

	private MyController mycontroller;
	private Vector3 direction;
	// Use this for initialization
	void Start () {
		direction = Random.insideUnitSphere;
		mycontroller = MyController.Instance ();
		mycontroller.FoundMe ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction *Time.deltaTime);
	}
}
