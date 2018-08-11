using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	private Rigidbody2D rb;

	public float speed;
	public float superSpeed;
	public float turnSpeed;

	private Vector2 moveDirection;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
		// rb.velocity = Vector2.right * 5;
	}

	void Update() {
		moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		if (moveDirection != Vector2.zero) {
			float t = turnSpeed * Time.deltaTime;
			float angle = Vector2.SignedAngle(Vector2.up, moveDirection);
			transform.rotation = Quaternion.Euler(0f, 0f, Mathf.LerpAngle(transform.rotation.eulerAngles.z, angle, t));
		}
	}

	void FixedUpdate() {
	 	if (Input.GetKey(KeyCode.LeftShift)) {
			rb.AddForce(moveDirection * superSpeed);
		} else {
			rb.AddForce(moveDirection * speed);
		}
	}
}