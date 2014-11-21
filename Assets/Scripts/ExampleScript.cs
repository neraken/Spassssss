using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class ExampleScript : MonoBehaviour {

	//public Transform myTransform;
	private Rigidbody myRigidBody;
	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent <Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//myTransform.position = Vector3.up * Time.time;
		myRigidBody.AddForce (Vector3.up *50);
	}
}
