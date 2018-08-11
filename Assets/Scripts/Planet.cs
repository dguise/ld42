using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
	public GameObject player;
	public float gravitation;
	public float gravitationRadius;

	private Rigidbody2D rbPlayer;

	void Start () {
		rbPlayer = player.GetComponent<Rigidbody2D>();
        
	}
	
	void Update () {
        
        float dist = Vector2.Distance(transform.position, player.transform.position);
		if (dist < gravitationRadius) {
			Vector2 force = (transform.position - player.transform.position).normalized * gravitation * (gravitationRadius - dist);
			rbPlayer.AddForce(force);
		}
	}

	void OnDrawGizmos() {
        Gizmos.color = Random.ColorHSV();
		Gizmos.DrawWireSphere(transform.position, gravitationRadius);
	}
}
