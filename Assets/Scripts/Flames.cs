using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour
{
    public float shakeIntensity = 0.1f;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void FixedUpdate()
    {

        var random = Random.Range(0.0f, 10.0f);
        if (random > 3)
        {
            Vector3 newPos = pos + Random.insideUnitSphere * shakeIntensity;
            newPos.z = pos.z;

            transform.position = newPos;
        }
    }
}
