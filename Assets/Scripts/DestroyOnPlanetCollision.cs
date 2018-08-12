using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPlanetCollision : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "Planet") {
			Destroy(gameObject);
		}
	}
}
