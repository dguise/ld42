using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarController : MonoBehaviour {

    Rigidbody2D rb;
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        if ((Input.GetButton("Fire1")))
        {
            rb.AddRelativeForce(new Vector2(0.5f, 0), ForceMode2D.Impulse);
        }
    }
}
