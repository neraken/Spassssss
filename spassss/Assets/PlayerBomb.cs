using UnityEngine;
using System.Collections;

public class PlayerBomb : MonoBehaviour {

	void onTriggerEnter(Collider other)
	{
		if (other.tag == "enemy") {
			Destroy (other.gameObject);
		}

	}

}
