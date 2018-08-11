using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGrower : MonoBehaviour
{

    Vector3 baseScale;
    float scalingStrength = 10.0f;
    float scalingSpeed = 2;

    void Start()
    {
        baseScale = transform.localScale;
        
    }


    void Update()
    {
        if ((Input.GetButton("Fire1")))
        {
            Debug.Log("Button Fire1 is DOWN " + Input.GetButton("Fire1"));
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(baseScale.x, baseScale.y + scalingStrength, baseScale.z), Time.deltaTime * scalingSpeed);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, baseScale, Time.deltaTime * scalingSpeed);
        }

    }
}
