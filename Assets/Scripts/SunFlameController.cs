using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlameController : MonoBehaviour {
	public GameObject flame;
	public float offset;
	public Vector3 flameScaleFactor;

	private Quaternion rot = Quaternion.Euler(0, 90, 0);

    void OnCollisionEnter2D(Collision2D col) {
		Vector3 v = col.collider.transform.position;
		Vector3 scl = col.collider.transform.localScale;
		v.x -= offset * scl.x;

		GameObject obj = Instantiate(flame, v, rot);
		scl.x *= flameScaleFactor.x;
		scl.y *= flameScaleFactor.y;
		scl.z *= flameScaleFactor.z;
		obj.transform.Find("PS").localScale = scl;

		Destroy(obj, 2f * scl.y);
		Destroy(col.gameObject, 2f * scl.y);
    }
}
