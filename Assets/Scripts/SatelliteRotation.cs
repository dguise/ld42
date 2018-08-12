using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteRotation : MonoBehaviour {
	private Vector3 rotationPoint;
	public float rotationSpeed;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rotationPoint = transform.Find("RotationPoint").transform.position;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(rotationPoint, new Vector3(0, 0, 1), rotationSpeed * Time.deltaTime);
	}

	void OnCollisionEnter2D(Collision2D col) {
		rb.bodyType = RigidbodyType2D.Dynamic;
		Destroy(this);
	}
}
