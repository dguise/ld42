using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
	public GameObject player;
	public float gravitation;
	public float gravitationRadius;

	private Rigidbody2D rbPlayer;

	// Use this for initialization
	void Start () {
		rbPlayer = player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector2.Distance(transform.position, player.transform.position);
		if (dist < gravitationRadius) {
			Vector2 force = (transform.position - player.transform.position).normalized * gravitation * (gravitationRadius - dist);
			//Debug.Log(force.magnitude);
			rbPlayer.AddForce(force);
		}
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, gravitationRadius);
	}
}
