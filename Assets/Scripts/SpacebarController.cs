using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarController : MonoBehaviour {

    RigidBody2D rb;
	void Start () {
        rb = this.GetComponent<RigidBody2D>;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
