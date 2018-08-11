using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSunLikeAKebabSpett : MonoBehaviour {


    public float rotationX = 0f;
    public float rotationY = 0f;
    public float rotationZ = 0.01f;

    void Update () {
        this.transform.Rotate(rotationX, rotationY, rotationZ);
    }
}
