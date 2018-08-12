using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSun : MonoBehaviour {

    Transform player;

    float speed = 3;
    float rubberBandRadius = 54;

    private void Start()
    {
        player = GameManager.Player.transform;
    }

    void Update () {
		Vector3 v = transform.position;

		if (player.position.x - transform.position.x > rubberBandRadius) {
			v.x = player.position.x - rubberBandRadius;
		}
		v.x += speed * Time.deltaTime;
		transform.position = v;
	}
}
