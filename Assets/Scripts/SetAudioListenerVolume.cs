﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAudioListenerVolume : MonoBehaviour {
	public float volume;

	// Use this for initialization
	void Start () {
		AudioListener.volume = volume;
	}
}
