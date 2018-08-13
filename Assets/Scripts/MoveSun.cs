using Assets.Scripts.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSun : MonoBehaviour {

    Transform player;

    public float speed = 3;
    public float rubberBandRadius = 54;

    private float startBurningSoundDistance = 20;
    private float startDangerSoundDistance = 30;

    private void Start()
    {
        player = GameManager.Player.transform;
    }

    void Update () {
		Vector3 v = transform.position;
        var distance = player.position.x - transform.position.x;

        if (distance > rubberBandRadius) {
			v.x = player.position.x - rubberBandRadius;
		}
		v.x += speed * Time.deltaTime;
		transform.position = v;

        AudioManager.instance.ChangeBurningVolume(1 - (distance - 40) / startBurningSoundDistance);
        AudioManager.instance.ChangeMusicVolume(1 - (distance - 40) / startDangerSoundDistance);
    }
}
