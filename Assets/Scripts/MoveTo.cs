using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(4.310709f, 1.85f, 3.417806f), Time.deltaTime);
	
		
	}
}
