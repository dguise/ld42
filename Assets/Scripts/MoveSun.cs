using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSun : MonoBehaviour {
	public float speed;
	public Transform player;
	public float rubberBandRadius;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = transform.position;
		if (player.position.x - transform.position.x > rubberBandRadius) {
			v.x = player.position.x - rubberBandRadius;
		}
		v.x += speed * Time.deltaTime;
		transform.position = v;
	}
}
