using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacebarController : MonoBehaviour {
    private Rigidbody2D rb;

    private float spaceStartTime;

    public float timeScale;
    public float turnSpeed;

	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            spaceStartTime = Time.time;
            Debug.Log("SPACE TIME: " + spaceStartTime);
            // rb.AddRelativeForce(new Vector2(0.5f, 0), ForceMode2D.Impulse);
        } else if(Input.GetKeyUp(KeyCode.Space)) {
            float timeDiff = Time.time - spaceStartTime;
            rb.AddForce(transform.right * timeDiff * timeScale);
            Debug.Log("TIME DIFF: " + timeDiff);
        }

        if (Input.GetKey(KeyCode.A)) {
			float t = turnSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + Mathf.LerpAngle(0, 5, t));
        } else if (Input.GetKey(KeyCode.D)) {
			float t = turnSpeed * Time.deltaTime;
			transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + Mathf.LerpAngle(0, -5, t));
        }
    }
}
